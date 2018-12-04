using LoESoft.Dlls.Database;
using LoESoft.Server.Core.Database.Models;
using LoESoft.Server.Core.Utils;
using LoESoft.Server.Core.World.Entities;
using LoESoft.Server.Utils;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

namespace LoESoft.Server.Core.Database
{
    public class Database : LoEDb, IDisposable
    {
        public static long LastAccountId = 0;

        public static ConcurrentDictionary<KeyValuePair<string, string>, Account> Accounts { get; set; }
        public static ConcurrentDictionary<KeyValuePair<long, long>, Character> Characters { get; set; }

        public const string AccountSubFolder = "Accounts";
        public const string CharacterSubFolder = "Characters";

        public string AccountsDir => GetSubDirectory(AccountSubFolder);
        public string CharactersDir => GetSubDirectory(CharacterSubFolder);

        public Database()
            : base(App.Name, true, (message) => App.Warn(message))
        {
            Accounts = new ConcurrentDictionary<KeyValuePair<string, string>, Account>();
            Characters = new ConcurrentDictionary<KeyValuePair<long, long>, Character>();

            CreateMainDirectory();
            CreateSubDirectory(AccountSubFolder);
            CreateSubDirectory(CharacterSubFolder);

            LoadAccounts();
            LoadCharacters();

            LastAccountId = Accounts.Count;
        }

        private void LoadAccounts()
            => Directory.EnumerateFiles(AccountsDir, Format).Select(file =>
            {
                var account = Load<Account>(AccountsDir, Path.GetFileNameWithoutExtension(new FileInfo(file).Name));

                if (account != null)
                    Accounts.TryAdd(new KeyValuePair<string, string>(account.Name, account.Password), account);

                return file;
            }).ToList();

        private void LoadCharacters()
            => Directory.EnumerateFiles(CharactersDir, Format).Select(file =>
            {
                var character = Load<Character>(CharactersDir, Path.GetFileNameWithoutExtension(new FileInfo(file).Name));

                if (character != null)
                    Characters.TryAdd(new KeyValuePair<long, long>(character.AccountId, character.Id), character);

                return file;
            }).ToList();

        private void SaveAccounts()
        {
            foreach (var i in Accounts.Values)
                Save(AccountsDir, $"account.{i.Id}", i);
        }

        private void SaveCharacters()
        {
            foreach (var i in Characters.Values)
                Save(CharactersDir, $"character.{i.Id}", i);
        }

        public Account GetAccountByCredentials(string name, string password)
            => Accounts.TryGetValue(new KeyValuePair<string, string>(name, password), out Account account) ? account : null;

        public Character GetCharacterByAccountId(long accountId, long characterId)
            => Characters.TryGetValue(new KeyValuePair<long, long>(accountId, characterId), out Character character) ? character : null;

        public List<Character> GetCharactersByAccountId(long accountId, out string error)
        {
            var account = Accounts.Values.FirstOrDefault(acc => acc.Id == accountId);

            if (account == null)
            {
                error = "Account is null.";
                return null;
            }

            error = null;
            return Characters.Where(acc => acc.Key.Key == account.Id).Select(character => character.Value).ToList();
        }

        public bool CheckAccountNameIfExists(string name)
            => Accounts.Keys.Select(names => names.Key).ToList().FirstOrDefault(data => data == name) != null;

        public bool CreateNewAccount(string name, string password, out string token)
        {
            token = Cipher.Encode($"{Cipher.LoESoftHash}+{name}+{password}+{Cipher.LoESoftHash}");

            return Accounts.TryAdd(new KeyValuePair<string, string>(name, password), new Account()
            {
                Id = Interlocked.Increment(ref LastAccountId),
                CurrentCharacterId = 0,
                Name = name,
                Password = password,
                Rank = 0,
                Token = token,
                Creation = DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss UTC")
            });
        }
        
        public bool CreateNewCharacter(long accountId, int world, int classType, out string error)
        {
            var account = Accounts.Values.FirstOrDefault(acc => acc.Id == accountId);

            if (account == null)
            {
                error = "Account is null.";
                return false;
            }

            if (account.CurrentCharacterId == 3)
            {
                error = "Max number of characters reached the limit.";
                return false;
            }

            var inv = new Item[32];
            for (var i = 0; i < 32; i++)
                inv[i] = new Item(LoERandom.Next(9, 11));

            var character = new Character()
            {
                Id = account.CurrentCharacterId,
                AccountId = accountId,
                World = world,
                Class = classType,
                Position = new Position()
                {
                    X = 0,
                    Y = 0
                },
                Creation = DateTime.UtcNow.ToString("dd-MM-yyyy HH:mm:ss UTC"),
                Inventory = inv
            };

            account.CurrentCharacterId++;

            error = null;
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