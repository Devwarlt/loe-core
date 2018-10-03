using System;
using System.Collections.Generic;

namespace LoESoft.Launcher.Controls.AccountDisplay
{
    public class ControlEvent : EventArgs
    {
        [Flags]
        public enum EventFlags
        {
            ACCOUNT_NAME_INVALID_LENGTH,
            ACCOUNT_NAME_NULL_OR_EMPTY,
            ACCOUNT_PASSWORD_INVALID_LENGTH,
            ACCOUNT_PASSWORD_NULL_OR_EMPTY,
            ACCOUNT_PASSWORD_DOESNT_MATCH
        }

        private readonly Dictionary<EventFlags, string> EventsWarning = new Dictionary<EventFlags, string>()
        {
            { EventFlags.ACCOUNT_NAME_INVALID_LENGTH, "Account name minimum length is 6" },
            { EventFlags.ACCOUNT_NAME_NULL_OR_EMPTY, "Account name could not be empty" },
            { EventFlags.ACCOUNT_PASSWORD_INVALID_LENGTH, "Account password minimum length is 8" },
            { EventFlags.ACCOUNT_PASSWORD_NULL_OR_EMPTY, "Account password could not be empty" },
            { EventFlags.ACCOUNT_PASSWORD_DOESNT_MATCH, "Account password does not match" }
        };

        private EventFlags EventFlag { get; set; }

        public ControlEvent(EventFlags eventFlag)
        {
            EventFlag = eventFlag;
        }

        public string GetNotificationByFlag => EventsWarning[EventFlag];
    }
}
