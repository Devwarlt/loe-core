using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game.Objects;
using LoESoft.Client.Core.Game.Objects.Stats;
using LoESoft.Client.Core.Game.User.Data;
using LoESoft.Client.Core.Game.User.GUI;
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
        public PlayerHUD HUD { get; set; }

        public int ObjectId { get; private set; }

        public GamePlayer(GameUser user, int objId, int classType)
        {
            CanMove = true;
            User = user;
            ObjectId = objId;
            
            HUD = new PlayerHUD();
            Player = new Player(classType);

            Player.ObjectId = ObjectId;
            Player.Init();
        }

        public void ImportStat(string export)
        {
            var stats = JsonConvert.DeserializeObject<List<string>>(export);

            foreach (var i in stats)
            {
                var stat = JsonConvert.DeserializeObject<Stat>(i);

                Player.ChangeStat(stat.StatType, stat.Value);

                if (stat.StatType == StatType.INVENTORY)
                    HUD.InfoTable.Init(Player.Inventory);
            }
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