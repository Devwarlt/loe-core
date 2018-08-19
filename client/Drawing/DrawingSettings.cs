using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LoESoft.Client.Drawing
{
    public static class DrawingSettings
    {
        public static ContentManager Content { get; private set; }

        public static void Load(ContentManager manager) => Content = manager;

        public static Texture2D GetTexture(string name) => Content.Load<Texture2D>($"images/{name}");
    }
}
