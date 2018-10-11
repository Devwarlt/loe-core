using LoESoft.WebServer.Core.Utils;

namespace LoESoft.WebServer.Core.Networking.Packets.Outgoing
{
    public class CheckVersion : PacketBase
    {
        public override void Handle()
        {
            string version = Query["version"];

            if (string.IsNullOrWhiteSpace(version))
            {
                OnError("Game version is invalid.");
                return;
            }

            if (!GameVersion.Verify(version))
            {
                OnError($"[Version {GameVersion.Latest.Version} released!] A brand-new version is now available! Confirm update to play.|{GameVersion.Latest.Link}");
                return;
            }

            OnSend();
        }
    }
}
