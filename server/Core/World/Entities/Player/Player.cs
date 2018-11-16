using LoESoft.Server.Core.Database.Models;
using LoESoft.Server.Core.Networking;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public partial class Player : Entity
    {
        public Client Client { get; private set; }
        public Character Character { get; private set; }

        public Player(WorldManager manager, Client client, Character character) 
            : base(manager, character.Class)
        {
            Client = client;
            Character = character;
            X = Character.Position.X;
            Y = Character.Position.Y;
        }

        public void Save()
        {
            App.Database.SaveCharacter(Character);
        }

        public override void Dispose()
        {
            Save();
            Manager.TryRemovePlayer(Client);
        }
    }
}