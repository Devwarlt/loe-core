using System;
using System.Drawing;

namespace LoESoft.Client.Core.GUI.GameDialog
{
    public class GameDialogSettings
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ContentAlignment Alignment { get; set; }
        public Action OnDisplay { get; set; }
        public Action OnClose { get; set; }
    }
}