using System;
using System.Drawing;

namespace LoESoft.Launcher.Controls
{
    public class PopUpSettings
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public ContentAlignment Alignment { get; set; }
        public Action OnDisplay { get; set; }
        public Action OnClose { get; set; }
    }
}