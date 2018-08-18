using LoESoft.Client.Core.networking.gameuser;

namespace LoESoft.Client.Core.networking.gamenetwork
{
    public class NetworkLoop
    {
        private GameUser _gameUser { get; set; }

        public NetworkLoop(GameUser gameUser)
        {
            _gameUser = gameUser;
        }

        public void Start()
        {

        }
    }
}
