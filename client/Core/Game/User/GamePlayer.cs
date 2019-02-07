using LoESoft.Client.Core.Game.Objects;
using LoESoft.Client.Core.Game.Objects.Stats;
using LoESoft.Client.Core.Game.User.GUI;
using LoESoft.Client.Core.Models;
using LoESoft.Client.Core.Networking;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace LoESoft.Client.Core.Game.User
{
    public class GamePlayer
    {
        public Player Player { get; private set; }
        public PlayerInfo Info { get; private set; }

        public PlayerHUD HUD { get; private set; }

        public int ObjectId { get; set; }

        public GamePlayer(PlayerInfo info)
        {
            Info = info;

            HUD = new PlayerHUD();
            Player = new Player(Info.ClassId);

            ObjectId = Info.ObjectId;
            Player.ObjectId = Info.ObjectId;
            CanMove = true;

            // for debug purposes
            var moveTask = new Task(() => MoveMonitor(), TaskCreationOptions.LongRunning);
            moveTask.ContinueWith(mt => App.Error(mt.Exception.InnerException),
                TaskContinuationOptions.OnlyOnFaulted);
            moveTask.Start();

            Player.Init();
            HUD.InfoTable.ReloadInventoryPlayer(this);
        }

        public int MoveEntryId = 0;

        private enum MoveState
        {
            Awaiting,
            Complete
        }

        private ConcurrentDictionary<int, (MoveState state, DateTime get, DateTime set)> MoveEntries
            = new ConcurrentDictionary<int, (MoveState state, DateTime get, DateTime set)>();

        private void AddMoveEntry()
            => MoveEntries.TryAdd(Interlocked.Increment(ref MoveEntryId),
                (MoveState.Awaiting, DateTime.Now, default));

        private void UpdateMoveEntry()
            => MoveEntries[MoveEntryId] = (MoveState.Complete, MoveEntries[MoveEntryId].get, DateTime.Now);

        private string GetMoveEntryElapsedTime()
            => $"- Response Time: {(MoveEntries[MoveEntryId].set - MoveEntries[MoveEntryId].get).TotalMilliseconds} ms";

        private async void MoveMonitor()
        {
            App.Warn($"- Can move? {CanMove}");
            App.Warn($"- Is moving? {Player.IsMoving}");
            App.Warn($"- Total move entries: {MoveEntries.Keys.Count}");

            if (MoveEntries.Keys.Count != 0)
            {
                var (state, get, set) = MoveEntries[MoveEntryId];

                App.Warn($"- Move ID {MoveEntryId}: {state} " +
                    $"- get: {get.ToString("MM/dd/yyyy hh:mm tt")}" +
                    $"{(set == default ? "" : $" - set: {set.ToString("MM/dd/yyyy hh:mm tt")}")}");

                if (set != default)
                    App.Warn(GetMoveEntryElapsedTime());
            }

            await Task.Delay(TimeSpan.FromSeconds(1));

            MoveMonitor();
        }

        public void ImportStat(Stat[] stats)
        {
            foreach (var i in stats)
                Player.ChangeStat(i.StatType, i.Data);

            if (stats.ToList().Exists(_ => _.StatType >= StatType.INVENTORY_0 && _.StatType <= StatType.INVENTORY_31))
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

            UpdateMoveEntry();
        }

        public void Update(GameTime gameTime)
        {
            HandlePlayerInput();
            Player.Update(gameTime);
            HUD.Update(gameTime);
            HUD.UpdateStatus(Player.Name, Player.Health, Player.MaximumHealth);
        }

        public void Draw(SpriteBatch spriteBatch)
        {
            Player.Draw(spriteBatch);

            spriteBatch.End();
            spriteBatch.Begin();

            HUD.Draw(spriteBatch);
            HUD.DrawMinimap(spriteBatch, (int)Player.X, (int)Player.Y);
        }

        private void SendMovePacket()
        {
            AddMoveEntry();
            NetworkClient.SendPacket(new ClientMove() { Direction = (int)Player.CurrentDirection });
        }
    }
}