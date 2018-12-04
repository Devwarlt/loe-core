using LoESoft.Server.Core.Database.Models;
using LoESoft.Server.Core.Networking;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public partial class Player : Entity
    {
        public Client Client { get; private set; }
        public Character Character { get; private set; }

        private Item[] _inventory;
        public Item[] Inventory
        {
            get => _inventory;
            set => IncrementVar(ref _inventory, value);
        }
        
        public Player(WorldManager manager, Client client, Character character)
            : base(manager, character.Class)
        {
            IsPlayer = true;

            Client = client;
            Character = character;
            X = Character.Position.X;
            Y = Character.Position.Y;

            Inventory = new Item[32];
            for (var i = 0; i < Character.Inventory.Length; i++)
                Inventory[i] = Character.Inventory[i];
        }

        public void Save()
        {
            Character.Position.X = X;
            Character.Position.Y = Y;
            Character.Inventory = Inventory;

            App.Database.SaveCharacter(Character);
        }

        public override void Dispose()
        {
            Save();
            Manager.TryRemovePlayer(Client);
        }
    }
}