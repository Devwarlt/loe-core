﻿using LoESoft.Client.Drawing.Sprites;

namespace LoESoft.Client.Drawing.Events
{
    public static class EventsManager
    {
        public static SpriteNode CurrentNode { get; private set; }

        static EventsManager()
        {
            CurrentNode = null;
        }

        public static void TrySet(SpriteNode node)
        {
            /*
             If the sprite is the current sprite let it still set in case of a moving sprite!
             */
            if (!EventsHandler.MouseRectangle.Intersects(node.SpriteRectangle))
                return;

            if (CurrentNode == null)
                CurrentNode = node;
            else if (node.SpriteLevel >= CurrentNode.SpriteLevel)
            {
                if (node.SpriteLevel == CurrentNode.SpriteLevel && node.Index > CurrentNode.Index)
                    CurrentNode = node;
                else if (node.SpriteLevel > CurrentNode.SpriteLevel)
                    CurrentNode = node;
            }
        }

        public static bool IsValid(SpriteNode node) => (CurrentNode != null &&
            CurrentNode.SpriteLevel == node.SpriteLevel && CurrentNode.Index == node.Index);

        public static void Update()
        {
            // Checks if the currentnode is still a valid node
            if (CurrentNode == null)
                return;

            if (!EventsHandler.MouseRectangle.Intersects(CurrentNode.SpriteRectangle))
            {
                GameClient.Warn($"{CurrentNode.X} was nulled!");
                CurrentNode = null;
            }
        }
    }
}