using LoESoft.Server.utils;

namespace LoESoft.Server.settings
{
    public class Settings
    {
        public TCPServerSettings _tcpServer { get; set; }

        public static Settings Default =>
            new Settings()
            {
                _tcpServer = new TCPServerSettings()
                {
                    _port = -1,
                    _maxClients = -1
                }
            };
    }
}
