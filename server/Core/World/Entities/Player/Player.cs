using LoESoft.Server.Core.Database.Models;
using LoESoft.Server.Core.Networking;
using LoESoft.Server.Core.World.Entities.Player.Attribute;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public partial class Player : EntityObject
    {
        public Client Client { get; private set; }
        public Character Character { get; private set; }
        public Inventory Inventory { get; private set; }

        public Player(WorldManager manager, Client client, Character character)
            : base(manager, character.Class)
        {
            Client = client;
            Character = character;
            X = Character.Position.X;
            Y = Character.Position.Y;
            Inventory = Character.Inventory;
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