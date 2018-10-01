using System;

namespace LoESoft.Launcher.Controls.AccountDisplay
{
    public class PopUpSettings
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Action WhenDisplay { get; set; }
        public Action WhenClose { get; set; }
    }
}
