﻿using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using ButtonState = Microsoft.Xna.Framework.Input.ButtonState;

namespace LoESoft.MapEditor.Core.Layer
{
    public class Layer
    {
        public const int TILE_SIZE = 16;

        public MapLayer MapLayer { get; set; }
        public MapSize MapSize { get; set; }
        public ChunkData[,] Chunk { get; set; }

        public Layer(MapLayer layer, MapSize size)
        {
            MapLayer = layer;
            MapSize = size;
            Chunk = new ChunkData[(int)MapSize, (int)MapSize];
        }

        public void SetTiles(MouseState mouse, ChunkData data)
        {
            Vector2 mouseposition;
            double mousemapx;
            double mousemapy;

            var leftbutton = mouse.LeftButton;
            var rightbutton = mouse.RightButton;

            try
            {
                if (leftbutton == ButtonState.Pressed)
                {
                    mouseposition = new Vector2(mouse.X, mouse.Y);
                    mousemapx = ((int)mouseposition.X / TILE_SIZE) + MapEditor.DrawOffset.X;
                    mousemapy = ((int)mouseposition.Y / TILE_SIZE) + MapEditor.DrawOffset.Y;

                    if (mouseposition.X < MapEditor.GraphicsDeviceManager.PreferredBackBufferWidth && mouseposition.X >= 0
                        && mouseposition.Y < MapEditor.GraphicsDeviceManager.PreferredBackBufferHeight && mouseposition.Y >= 0
                        && mousemapx < (int)MapSize && mousemapx >= 0
                        && mousemapy < (int)MapSize && mousemapy >= 0
                        && App.MapEditor.IsActive)
                        Chunk[(int)mousemapx, (int)mousemapy] = data;
                }

                if (rightbutton == ButtonState.Pressed)
                {
                    mouseposition = new Vector2(mouse.X, mouse.Y);
                    mousemapx = ((int)mouseposition.X / TILE_SIZE) + MapEditor.DrawOffset.X;
                    mousemapy = ((int)mouseposition.Y / TILE_SIZE) + MapEditor.DrawOffset.Y;

                    if (mouseposition.X < MapEditor.GraphicsDeviceManager.PreferredBackBufferWidth && mouseposition.X >= 0
                        && mouseposition.Y < MapEditor.GraphicsDeviceManager.PreferredBackBufferHeight && mouseposition.Y >= 0
                        && mousemapx < (int)MapSize && mousemapx >= 0
                        && mousemapy < (int)MapSize && mousemapy >= 0
                        && App.MapEditor.IsActive)
                        Chunk[(int)mousemapx, (int)mousemapy] = null;
                }
            }
            catch { }
        }
    }
}