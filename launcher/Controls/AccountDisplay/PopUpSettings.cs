using System;

namespace LoESoft.Launcher.Controls.AccountDisplay
{
    public class PopUpSettings
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public Action Action { get; set; }
        public Action ExtraAction { get; set; }
    }
}
