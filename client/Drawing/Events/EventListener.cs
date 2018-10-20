using System;

namespace LoESoft.Client.Drawing.Events {
    public class EventListener {
        public MouseEvent MouseEvent { get; set; }
        public Action MouseAction { get; set; }
    }
}