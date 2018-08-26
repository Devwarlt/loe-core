using System.Collections.Generic;

namespace LoESoft.Client.Core.Utils
{
    public class TextLabel
    {
        private static readonly Dictionary<TextType, string> _texts = new Dictionary<TextType, string>()
        {
            { TextType.CONNECTION_FAILED, "Connection failed! Retrying..." },
            { TextType.CONNECTION_FAILED_WITH_ATTEMPTS, $"[Attempts: {{ATTEMPTS}}] Connection failed! Retrying..." },
            { TextType.CONNECTION_LOST, "Connection lost! Retrying..." },
            { TextType.CONNECTION_LOST_WITH_ATTEMPTS, $"[Attempts: {{ATTEMPTS}}] Connection lost! Retrying..." },
            { TextType.CONNECTION_ATTEMPT_TO_CONNECT, "Attempting to connect to the game server..." },
            { TextType.CONNECTION_STABLISHED, $"[Attempts:{{ATTEMPTS}}] The game client has been connected to IP '{{DNS}}' via port '{{PORT}}'!" }
        };

        private static readonly Dictionary<LabelType, string> _labels = new Dictionary<LabelType, string>()
        {
            { LabelType.ATTEMPTS, "{ATTEMPTS}" },
            { LabelType.DNS, "{DNS}" },
            { LabelType.PORT, "{PORT}" }
        };

        public static string GetText(TextType textType) => _texts[textType];

        public static string GetText(TextType textType, KeyValuePair<LabelType, string>[] textParams)
        {
            var message = GetText(textType);
            foreach (var textParam in textParams)
                message = message.Replace(_labels[textParam.Key], textParam.Value);
            return message;
        }

        public static KeyValuePair<LabelType, string>[] AddParams(TextParams textParams) => new KeyValuePair<LabelType, string>[] { new KeyValuePair<LabelType, string>(textParams._labelType, textParams._value.ToString()) };

        public static KeyValuePair<LabelType, string>[] AddParams(TextParams[] textParams)
        {
            var data = new List<KeyValuePair<LabelType, string>>();
            foreach (var textParam in textParams)
                data.Add(new KeyValuePair<LabelType, string>(textParam._labelType, textParam._value.ToString()));
            return data.ToArray();
        }
    }

    public class TextParams
    {
        public LabelType _labelType { get; private set; }
        public object _value { get; set; }

        public TextParams(LabelType labelType, object value)
        {
            _labelType = labelType;
            _value = value;
        }
    }

    public enum TextType : int
    {
        CONNECTION_FAILED,
        CONNECTION_FAILED_WITH_ATTEMPTS,
        CONNECTION_LOST,
        CONNECTION_LOST_WITH_ATTEMPTS,
        CONNECTION_ATTEMPT_TO_CONNECT,
        CONNECTION_STABLISHED
    }

    public enum LabelType : int
    {
        ATTEMPTS,
        DNS,
        PORT
    }
}
