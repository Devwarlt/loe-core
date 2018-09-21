using LoESoft.WebServer.Core.Database.Models;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Security.Cryptography;
using System.Text;

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
        public Account GetAccountById(int id)
        {
            using (var cmd = new SQLiteCommand(Connection))
            {
                cmd.CommandText = "SELECT name, password FROM accounts WHERE id = @id;";
                cmd.Parameters.AddWithValue("@id", id);

                using (var row = cmd.ExecuteReader())
                    while (row.Read())
                        return new Account()
                        {
                            Id = id,
                            Name = (string)row["name"],
                            Password = (string)row["password"]
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

        #region "Create methods"
        public void CreateNewAccount(string name, string password)
        {
            using (var cmd = new SQLiteCommand(Connection))
            {
                cmd.CommandText = "INSERT INTO accounts (name, password) VALUES (@name, @password);";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@password", Crypt(password));
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
                cmd.Parameters.AddWithValue("@positionId", 0); // still need to adjust this
                cmd.Parameters.AddWithValue("@positionX", 0); // still need to adjust this
                cmd.Parameters.AddWithValue("@positionY", 0); // still need to adjust this
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

        public static string Crypt(string value)
        {
            string hash = string.Empty;

            foreach (byte theByte in new HMACSHA512().ComputeHash(Encoding.ASCII.GetBytes(value + "_103s0f7 g4m3s_"), 0, Encoding.ASCII.GetByteCount(value + "_103s0f7 g4m3s_")))
                hash += theByte.ToString("x2");

            return hash;
        }
    }
}
