namespace LoESoft.Server.Settings
{
    public class ServerSettings
    {
        public TCPServerSettings TcpServerSettings { get; set; }

        public static ServerSettings DefaultServerSettings =>
            new ServerSettings()
            {
                TcpServerSettings = new TCPServerSettings()
                {
                    Port = -1,
                    MaxClients = -1
                }
            };
    }
}