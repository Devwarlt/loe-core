using System;
using System.Collections.Generic;
using System.Linq;

namespace LoESoft.WebServer.Core.Utils
{
    public class GameVersion
    {
        private static string URL => "https://github.com/LoESoft-Games/BRME/releases/download";

        public string Version { get; set; }
        public bool Allowed { get; set; }
        public string Link { get; set; }

        public GameVersion(string Version, bool Allowed, string Link)
        {
            this.Version = Version;
            this.Allowed = Allowed;
            this.Link = $"{URL}/{Link}";
        }

        /// <summary>
        /// Max 5 supported versions.
        /// </summary>
        /// <returns></returns>
        public static List<GameVersion> Supported =>
            GameWebServer._gameVersions.Count >= 5 ?
            GameWebServer._gameVersions.Skip(GameWebServer._gameVersions.Count - 5).ToList() :
            GameWebServer._gameVersions;

        /// <summary>
        /// Returns only available versions from supported versions.
        /// </summary>
        /// <returns></returns>
        public static List<GameVersion> Available =>
            Supported.Where(i => i.Allowed).ToList();

        /// <summary>
        /// Return latest supportable version to play (min version required).
        /// </summary>
        /// <returns></returns>
        public static GameVersion Latest =>
            Available[0];

        /// <summary>
        /// Verify if user version still supported.
        /// </summary>
        /// <param name="build"></param>
        /// <returns></returns>
        public static bool Verify(string build)
        {
            List<GameVersion> playableVersions = Available;

            foreach (GameVersion i in playableVersions)
                if (i.Version == build && i.Allowed)
                    return true;

            return false;
        }
    }
}
