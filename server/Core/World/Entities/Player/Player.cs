﻿using LoESoft.Server.Core.Networking;
using LoESoft.Server.Core.Networking.Packets.Outgoing;

namespace LoESoft.Server.Core.World.Entities.Player
{
    public class Player : Entity
    {
        public Client Client { get; private set; }

        public int X { get; set; } 
        public int Y { get; set; } 

        public Player(Client client)
        {
            Client = client;
        }

        public void UpdatePosition(int x, int y)
        {
            X = x;
            Y = y;

            GameServer.Info("Sending Update Packet!");

            Client.SendPacket(new Update()
            {
                TileData = WorldManager.Map.GetData(X, Y)
            });
        }
    }
}
