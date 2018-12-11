namespace LoESoft.Server.Core.Networking.Packets
{
    public enum PacketID : int
    {
        PONG = 0,
        PING = 1,
        CLIENTMOVE = 2,
        UPDATE = 3,
        LOAD = 4,
        SERVERMOVE = 5,
        LOGIN = 6,
        REGISTER = 7,
        CREATE_NEW_CHARACTER = 8,
        SERVER_RESPONSE = 9,
        LOAD_MAP = 10,
        CLIENT_REPONSE = 11,
        INVENTORY_SWAP = 12,
        PLAYER_UPDATE = 13,
        HELLO = 14
    }
}