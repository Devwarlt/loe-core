using LoESoft.Client.Drawing.Sprites;
using System.Diagnostics;
using System.Linq;

namespace LoESoft.Client.Drawing.Events
{
    public static class EventsManager
    {
        public static SpriteNode CurrentNode { get; private set; }

        static EventsManager() => CurrentNode = null;

        public static void TrySet(SpriteNode node)
        {
            if (isClientActive == false)
            {
                CurrentNode = null;
                return;
            }

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

        public static bool IsValid(SpriteNode node)
            => (CurrentNode != null && CurrentNode.SpriteLevel == node.SpriteLevel && CurrentNode.Index == node.Index);

        public static void Update()
        {
            handleUnactiveClient();

            // Checks if the currentnode is still a valid node
            if (CurrentNode == null)
                return;

            if (!EventsHandler.MouseRectangle.Intersects(CurrentNode.SpriteRectangle))
                CurrentNode = null;
        }

        private static bool isClientActive = true;

        private static void handleUnactiveClient()
        {
            int processId = Process.GetProcesses().Where(_ => _.ProcessName == "").First().Id;
            var curProcess = Process.GetCurrentProcess();

            isClientActive = (processId == curProcess.Id);
        }
    }
}