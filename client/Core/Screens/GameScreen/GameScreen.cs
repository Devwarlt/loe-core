#define TEMP_DISABLE

using LoESoft.Client.Core.Client;
using LoESoft.Client.Core.Game;
using LoESoft.Client.Core.Game.Objects;
using LoESoft.Client.Core.Networking;
using LoESoft.Client.Core.Networking.Packets.Outgoing;
using LoESoft.Client.Drawing;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Threading;

namespace LoESoft.Client.Core.Screens
{
    public class GameScreen : Screen
    {
        public static GameUser GameUser { get; set; }
        public Player TempPlayer { get; set; }

        public static Map PlayerMap { get; set; }

        private int X { get; set; } = 0;
        private int Y { get; set; } = 0;

        public override void OnScreenCreate()
        {
            GameUser = new GameUser(new Server("127.0.0.1", 7171));
            GameUser.Connect();

            TempPlayer = new Player();
            PlayerMap = new Map();

            UpdatePacketThread =
                new Thread(() =>
                {
                    if (!UpdatePacketActivated)
                        UpdatePacketActivated = true;

                    try
                    {
                        do
                        {
                            // The async method below is used to send sync packets using async wait handle.
                            if (!_sendPingOnce)
                            {
                                var value = new Random().Next();

                                GameClient.Info($"Client is sending value '{value}' via Ping packet.");

                                GameUser.SendSyncPacket(new Ping() { Value = value });

                                _sendPingOnce = true;
                            }

                            var playerX = (int)TempPlayer.X;
                            var playerY = (int)TempPlayer.Y;

                            if (X != playerX || Y != playerY)
                            {
                                X = playerX;
                                Y = playerY;

                                GameUser.SendPacket(new Move()
                                {
                                    X = playerX,
                                    Y = playerY
                                });
                            }

                            Thread.Sleep(100);
                        } while (true);
                    }
                    catch (Exception e) { GameClient.Error(e); }
                })
                { IsBackground = true };
        }

        public override void OnScreenDispatch() => GameUser.Disconnect();

        public bool _sendPingOnce = false;

        private bool UpdatePacketActivated = false;

        public Thread UpdatePacketThread;

        public override void Update(GameTime gameTime)
        {
            if (GameUser.IsConnected && !UpdatePacketActivated)
                UpdatePacketThread.Start();

            TempPlayer.Update(gameTime);

            Camera.SetFocus(TempPlayer);
        }

        public override void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Clear();

            spriteBatch.Begin(samplerState: SamplerState.PointClamp, transformMatrix: Camera.GetMatrix());

            PlayerMap.Draw(spriteBatch);

            TempPlayer.Draw(spriteBatch);
            spriteBatch.End();
        }
    }
}
