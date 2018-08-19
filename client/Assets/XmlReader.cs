using Microsoft.Xna.Framework.Content;
using System.Collections.Generic;
using System.Xml.Linq;
using LoESoft.Client.Properties;
using LoESoft.Client.Assets.Serialization;
using System;
using LoESoft.Client.Assets.Serialization.AssetTypes;

namespace LoESoft.Client.Assets
{
    public static class XmlReader
    {
        public static readonly Dictionary<AssetType, Tuple<string, string>> _assets = new Dictionary<AssetType, Tuple<string, string>>()
        {
            { AssetType.Vocation, new Tuple<string, string>(Resources.Vocations, "//Vocation") }
        };

        private static int _playersAmount { get; set; } = 0;

        public static Dictionary<int, XElement> XmlsDictionary { get; private set; }

        static XmlReader()
        {
            XmlsDictionary = new Dictionary<int, XElement>();
        }

        public static void Load(ContentManager contentManager)
        {
            string message = $"Loading {_assets.Count} asset{(_assets.Count > 1 ? "s" : "")}...";

            GameClient._log.Info(message);

            AssetSerialization.Serialize();

            GameClient._log.Info($"- {Vocation._assets.Count} Vocation{(Vocation._assets.Count > 1 ? "s" : "")} added.");
            GameClient._log.Info($"{message} OK!");
        }
    }
}
