using LoESoft.LCBase;
using LoESoft.Server.Core.Database.Models;
using LoESoft.Server.Core.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace LoESoft.Server.Core.Database
{
    public class Database : Base, IDisposable
    {
        public static long LastAccountId = 0;
        public static long LastCharacterId = 0;
        public static string AccountsPath => "accounts";
        public static string CharactersPath => "characters";
        public static ConcurrentDictionary<KeyValuePair<string, string>, Account> Accounts { get; set; }
        public static ConcurrentDictionary<KeyValuePair<long, long>, Character> Characters { get; set; }

        public Database() : base($"{App.Name}-base", (message) => App.Warn(message))
        {
            Accounts = new ConcurrentDictionary<KeyValuePair<string, string>, Account>();
            Characters = new ConcurrentDictionary<KeyValuePair<long, long>, Character>();

            CreateMainDirectory();
            CreateSubDirectory(AccountsPath);
            CreateSubDirectory(CharactersPath);

            LoadAccounts();
            LoadCharacters();

            LastAccountId = Accounts.Count;
            LastCharacterId = Characters.Count;
        }

        private void LoadAccounts()
        {
            foreach (var i in Directory.EnumerateFiles(Path.Combine(MainDir, $"/{BaseDir}/{AccountsPath}/"), "*.json"))
            {
                var account = Load<Account>(i);

                if (account != null)
                    Accounts.TryAdd(new KeyValuePair<string, string>(account.Name, account.Password), account);
            }
        }

        private void LoadCharacters()
        {
            foreach (var i in Directory.EnumerateFiles(Path.Combine(MainDir, $"/{BaseDir}/{CharactersPath}/"), "*.json"))
            {
                var character = Load<Character>(i);

                if (character != null)
                    Characters.TryAdd(new KeyValuePair<long, long>(character.AccountId, character.Id), character);
            }
        }

        private void SaveAccounts()
        {
            foreach (var i in Accounts.Values)
                Save(AccountsPath, $"account.{i.Id}", i);
        }

        private void SaveCharacters()
        {
            foreach (var i in Characters.Values)
                Save(CharactersPath, $"character.{i.Id}", i);
        }

        public Account GetAccountByCredentials(string name, string password)
            => Accounts.TryGetValue(new KeyValuePair<string, string>(name, password), out Account account) ? account : null;

        public Character GetCharacterByAccountId(long accountId, long characterId)
            => Characters.TryGetValue(new KeyValuePair<long, long>(accountId, characterId), out Character character) ? character : null;

        public bool CheckAccountNameIfExists(string name)
            => Accounts.Keys.Select(names => names.Key).ToList().FirstOrDefault(data => data == name) != null;

        public bool CreateNewAccount(string name, string password, out string token)
        {
            token = Cipher.Encode($"{Cipher.LoESoftHash}+{name}+{password}+{Cipher.LoESoftHash}");

            return Accounts.TryAdd(new KeyValuePair<string, string>(name, password), new Account()
            {
                Id = Interlocked.Increment(ref LastAccountId),
                Name = name,
                Password = password,
                Rank = 0,
                Token = token,
                Creation = DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss UTC")
            });
        }

        public bool CreateNewCharacter(long accountId, int world, string name)
        {
            var character = new Character()
            {
                Id = Interlocked.Increment(ref LastCharacterId),
                AccountId = accountId,
                World = world,
                Name = name,
                Class = 0,
                Position = new Position()
                {
                    Type = 0,
                    X = 0,
                    Y = 0
                },
                Creation = DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss UTC")
            };

            return Characters.TryAdd(new KeyValuePair<long, long>(character.AccountId, character.Id), character);
        }

        public void SaveCharacter(Character character)
            => Characters[new KeyValuePair<long, long>(character.AccountId, character.Id)] = character;

        public void Dispose()
        {
            SaveAccounts();
            SaveCharacters();
        }
    }
}