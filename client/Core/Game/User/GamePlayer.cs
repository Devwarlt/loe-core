using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game.Objects;
using LoESoft.Client.Core.Game.Objects.Stats;
using LoESoft.Client.Core.Game.User.GUI;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Client.Core.Game.User
{
    public class GamePlayer
    {
        public GameUser User { get; private set; }
        public Player Player { get; private set; }
        public PlayerHUD HUD { get; private set; }

        public int ObjectId { get; set; }

        public GamePlayer(GameUser user, int objId, int classType)
        {
            User = user;

            HUD = new PlayerHUD(user);
            Player = new Player(classType);

            CanMove = true;
            
            ObjectId = objId;
            Player.ObjectId = ObjectId;
            Player.Init();

            HUD.InfoTable.ReloadInventoryPlayer(this);
        }

        public void ImportStat(string export)
        {
            var stats = JsonConvert.DeserializeObject<IEnumerable<KeyValuePair<int, object>>>(export);

            foreach (var i in stats)
                Player.ChangeStat(i.Key, i.Value);

            if (stats.ToList().Exists(_ => _.Key >= StatType.INVENTORY_0 && _.Key <= StatType.INVENTORY_31))
                HUD.InfoTable.ReloadInventory(Player.Inventory);
        }
        
        public bool CanMove { get; set; }

        private void HandlePlayerInput()
        {
            if (Keyboard.GetState().GetPressedKeys().SkipWhile(_ => !Player.KeysToDirection.Keys.Contains(_)).Count() > 0)
            {
                Player.CurrentDirection = Player.KeysToDirection[Keyboard.GetState().GetPressedKeys().SkipWhile(_ => Player.KeysToDirection.Keys.Contains(_) ? false : true).First()];

                if (!Player.IsMoving && CanMove)
                {
                    SendMovePacket();
                    CanMove = false;
                }
            }
        }

        public void Override(int objId, int id)
        {
            ObjectId = objId;
            Player.Override(ObjectId, id);
        }

        public void SetDistination(int x, int y)
        {
            Player.DistinationX = x;
            Player.DistinationY = y;

            CanMove = true;
        }

        public void Update(GameTime gameTime)
        {
            HandlePlayerInput();
            Player.Update(gameTime);
            HUD.Update(gameTime);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Player.Draw(spriteBatch);

            spriteBatch.End();
            spriteBatch.Begin();

            HUD.Draw(spriteBatch);
            HUD.DrawMinimap(spriteBatch, this);
        }

        private void SendMovePacket() => User.SendPacket(new ClientMove() { Direction = (int)Player.CurrentDirection });
    }
}