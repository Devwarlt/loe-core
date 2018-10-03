using LoESoft.WebServer.Core.Database.Models;
using LoESoft.WebServer.Core.Utils;
using System;
using System.Collections.Generic;
using System.Data.SQLite;

namespace LoESoft.WebServer.Core.Database
{
    public class Database
    {
        private SQLiteConnection Connection { get; set; }

        public Database()
        {
            Connection = new SQLiteConnection("Data Source = ../../../database/brme.s3db");
        }

        public void Connect() => Connection.Open();

        public void Disconnect() => Connection.Close();

        #region "Get methods"
        public Account GetAccountByToken(string token)
        {
            using (var cmd = new SQLiteCommand(Connection))
            {
                cmd.CommandText = "SELECT * FROM accounts WHERE token = @token;";
                cmd.Parameters.AddWithValue("@token", token);

                using (var row = cmd.ExecuteReader())
                    while (row.Read())
                        return new Account()
                        {
                            Id = (int)row["id"],
                            Name = (string)row["name"],
                            Password = (string)row["password"],
                            Rank = (int)row["rank"],
                            Token = token,
                            Creation = (DateTime)row["creation"]
                        };
            }

            return null;
        }

        public Account GetAccountByCredentials(string name, string password)
        {
            using (var cmd = new SQLiteCommand(Connection))
            {
                cmd.CommandText = "SELECT * FROM accounts WHERE name = @name AND password = @password;";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@password", Cipher.Encode(password));

                using (var row = cmd.ExecuteReader())
                    while (row.Read())
                        return new Account()
                        {
                            Id = (int)row["id"],
                            Name = name,
                            Password = password,
                            Rank = (int)row["rank"],
                            Token = (string)row["token"],
                            Creation = (DateTime)row["creation"]
                        };
            }

            return null;
        }

        public List<Character> GetCharactersByAccount(Account account)
        {
            using (var cmd = new SQLiteCommand(Connection))
            {
                cmd.CommandText = "SELECT * FROM characters WHERE account = @account;";
                cmd.Parameters.AddWithValue("@account", account.Id);

                using (var row = cmd.ExecuteReader())
                {
                    List<Character> characters = new List<Character>();

                    while (row.Read())
                        characters.Add(new Character()
                        {
                            Id = (int)row["id"],
                            World = (int)row["world"],
                            Account = account,
                            Name = (string)row["name"],
                            Class = (int)row["class"],
                            PositionId = (int)row["positionId"],
                            PositionX = (int)row["positionX"],
                            PositionY = (int)row["positionY"],
                            Creation = (DateTime)row["creation"]
                        });

                    return characters.Count == 0 ? null : characters;
                }
            }
        }
        #endregion

        #region "Check methods"
        public bool CheckAccountNameIfExists(string name)
        {
            using (var cmd = new SQLiteCommand(Connection))
            {
                cmd.CommandText = "SELECT id FROM accounts WHERE name = @name;";
                cmd.Parameters.AddWithValue("@name", name);

                using (var row = cmd.ExecuteReader())
                    while (row.Read())
                        return true;
            }

            return false;
        }
        #endregion

        #region "Create methods"
        public void CreateNewAccount(string name, string password, out string token)
        {
            using (var cmd = new SQLiteCommand(Connection))
            {
                token = Cipher.Encode($"{Cipher.LoESoftHash}+{name}+{password}+{Cipher.LoESoftHash}");

                cmd.CommandText = "INSERT INTO accounts (name, password, rank, token, creation) VALUES " +
                    "(@name, @password, @rank, @token, @creation);";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@password", Cipher.Encode(password));
                cmd.Parameters.AddWithValue("@rank", 0);
                cmd.Parameters.AddWithValue("@token", token);
                cmd.Parameters.AddWithValue("@creation", DateTime.UtcNow);
                cmd.ExecuteNonQuery();
            }
        }

        public void CreateNewCharacter(Account account, int world, string name)
        {
            using (var cmd = new SQLiteCommand(Connection))
            {
                cmd.CommandText = "INSERT INTO characters (world, account, name, class, positionId, positionX, positionY, creation) VALUES " +
                    "(@world, @account, '@name', @class, @positionId, @positionX, @positionY, @creation);";
                cmd.Parameters.AddWithValue("@world", world);
                cmd.Parameters.AddWithValue("@account", account.Id);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@class", 0); // Apprentice as default
                cmd.Parameters.AddWithValue("@positionId", 0); // TODO: still need to adjust this
                cmd.Parameters.AddWithValue("@positionX", 0); // TODO: still need to adjust this
                cmd.Parameters.AddWithValue("@positionY", 0); // TODO: still need to adjust this
                cmd.Parameters.AddWithValue("@creation", DateTime.UtcNow);
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT id FROM characters WHERE account = @account;";
                cmd.Parameters.AddWithValue("@account", account.Id);

                using (var row = cmd.ExecuteReader())
                    while (row.Read())
                    {
                        cmd.CommandText = "INSERT INTO depots (character) VALUES (@character);";
                        cmd.Parameters.AddWithValue("@character", (int)row["id"]);
                        cmd.ExecuteNonQuery();
                        break;
                    }
            }
        }
        #endregion
    }
}
