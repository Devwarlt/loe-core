using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game.Objects;
using LoESoft.Client.Core.Game.Objects.Stats;
using LoESoft.Client.Core.Game.User.GUI;
using LoESoft.Client.Core.Models;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.Client.Core.Game.User
{
    public class GamePlayer
    {
        public GameUser User { get; private set; }
        public Player Player { get; private set; }
        public PlayerInfo Info { get; private set; }

        public PlayerHUD HUD { get; private set; }

        public int ObjectId { get; set; }

        public GamePlayer(GameUser user, PlayerInfo info)
        {
            User = user;
            Info = info;

            HUD = new PlayerHUD(user);
            Player = new Player(Info.ClassId);

            CanMove = true;
            ObjectId = Info.ObjectId;
            Player.ObjectId = Info.ObjectId;
            
            Player.Init();
            HUD.InfoTable.ReloadInventoryPlayer(this);
        }

        public void ImportStat(string export)
        {
            var stats = JsonConvert.DeserializeObject<IEnumerable<KeyValuePair<int, object>>>(export).ToList();

            foreach (var i in stats)
                Player.ChangeStat(i.Key, i.Value);

            if (stats.Exists(_ => _.Key >= StatType.INVENTORY_0 && _.Key <= StatType.INVENTORY_31))
                HUD.InfoTable.ReloadInventory(Player.Inventory);

            if (stats.Exists(_ => _.Key == StatType.NAME))
                HUD.InfoTable.Title.Text = Player.Name;
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
            HUD.UpdateStatusBar(Player.Health, Player.MaximumHealth);
            HUD.UpdateStatsView(Player.MaximumHealth);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Player.Draw(spriteBatch);

            spriteBatch.End();
            spriteBatch.Begin();

            HUD.Draw(spriteBatch);
            HUD.DrawMinimap(spriteBatch, (int)Player.X, (int)Player.Y);
        }

        private void SendMovePacket() => User.SendPacket(new ClientMove() { Direction = (int)Player.CurrentDirection });
    }
}