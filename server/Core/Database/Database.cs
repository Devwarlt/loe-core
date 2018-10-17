﻿using LoESoft.Server.Core.Database.Models;
using LoESoft.Server.Core.Utils;
using LoESoft.Server.Core.World.Map.Data;
using Newtonsoft.Json;
using System;
using System.Data.SQLite;

namespace LoESoft.Server.Core.Database
{
    public class Database
    {
        private SQLiteConnection Connection { get; set; }

        public Database() => Connection = new SQLiteConnection("Data Source = ../../../database/brme.s3db");

        public void Connect() => Connection.Open();

        public void Disconnect() => Connection.Close();

        #region "Get methods"

        public Account GetAccountByCredentials(string name, string password)
        {
            using (var cmd = new SQLiteCommand(Connection))
            {
                var encodedPass = Cipher.Encode(password);
                cmd.CommandText = "SELECT * FROM accounts WHERE name = @name AND password = @password;";
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@password", encodedPass);

                using (var row = cmd.ExecuteReader())
                    while (row.Read())
                        return new Account()
                        {
                            Id = (long)row["id"],
                            Name = name,
                            Password = password,
                            Rank = (int)row["rank"],
                            Token = (string)row["token"],
                            Creation = (string)row["creation"]
                        };
            }

            return null;
        }

        public Character GetCharacterByAccountId(int accountId, int characterId)
        {
            using (var cmd = new SQLiteCommand(Connection))
            {
                cmd.CommandText = "SELECT * FROM characters WHERE account = @account AND id = @id;";
                cmd.Parameters.AddWithValue("@account", accountId);
                cmd.Parameters.AddWithValue("@id", characterId);

                using (var row = cmd.ExecuteReader())
                    while (row.Read())
                        return new Character()
                        {
                            Id = characterId,
                            World = (int)row["world"],
                            Name = (string)row["name"],
                            Class = (int)row["class"],
                            Position = JsonConvert.DeserializeObject<Position>((string)row["position"]),
                            Creation = (string)row["creation"]
                        };
            }

            return null;
        }

        #endregion "Get methods"

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

        #endregion "Check methods"

        #region "Create methods"

        public bool CreateNewAccount(string name, string password, out string token)
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
                cmd.Parameters.AddWithValue("@creation", DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss UTC"));

                return cmd.ExecuteNonQuery() > 0;
            }
        }

        public bool CreateNewCharacter(int accountId, int world, string name)
        {
            using (var cmd = new SQLiteCommand(Connection))
            {
                cmd.CommandText = "INSERT INTO characters (world, account, name, class, position, creation) VALUES " +
                    "(@world, @account, '@name', @class, '@positionId', @creation);";
                cmd.Parameters.AddWithValue("@world", world);
                cmd.Parameters.AddWithValue("@account", accountId);
                cmd.Parameters.AddWithValue("@name", name);
                cmd.Parameters.AddWithValue("@class", 0); // Apprentice as default
                cmd.Parameters.AddWithValue("@position", new Position()
                {
                    Type = 0,
                    X = 0,
                    Y = 0
                });
                cmd.Parameters.AddWithValue("@creation", DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss UTC"));
                cmd.ExecuteNonQuery();

                cmd.CommandText = "SELECT id FROM characters WHERE account = @account;";
                cmd.Parameters.AddWithValue("@account", accountId);

                using (var row = cmd.ExecuteReader())
                    while (row.Read())
                    {
                        cmd.CommandText = "INSERT INTO depots (character) VALUES (@character);";
                        cmd.Parameters.AddWithValue("@character", (long)row["id"]);
                        return cmd.ExecuteNonQuery() > 0;
                    }
            }

            return false;
        }

        #endregion "Create methods"

        #region "Update methods"

        // This method ONLY save player position yet.
        public void SavePlayer(Account account, PlayerData data)
        {
            using (var cmd = new SQLiteCommand(Connection))
            {
                cmd.CommandText = "UPDATE characters SET position = '@position';";
                cmd.Parameters.AddWithValue("@position", JsonConvert.SerializeObject(new Position()
                {
                    Type = data.Type,
                    X = data.X,
                    Y = data.Y
                }));
                cmd.ExecuteNonQuery();
            }
        }

        #endregion "Update methods"
    }
}