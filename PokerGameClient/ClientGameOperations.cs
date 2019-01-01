using System.Collections.Generic;
using System.ServiceModel;
using System.Threading.Tasks;
using PokerGameClient.PokerGameServiceReference;
using PokerLibrary;

namespace PokerGameClient
{
    public class ClientGameOperations
    {
        private readonly PokerServiceClient _pokerServiceClient = new PokerServiceClient(new InstanceContext(new AcceptPokerCallBack()));

        public Task<Room[]> GetRoomsAsync()
        {
            return _pokerServiceClient.GetRoomsAsync();
        }
        public Player Register(string name)
        {
            return _pokerServiceClient.RegisterPlayer(name);
        }
        public Task<Room> JoinRoom(string name, string roomId)
        {
            return _pokerServiceClient.RegisterToRoomAsync(name, roomId);
        }
        public async void SendReady(string name, string roomId)
        {
            await _pokerServiceClient.SendReadyAsync(name, roomId);
        }

        public void TestConnection()
        {
            _pokerServiceClient.TestConnection();
        }

        public Room GetRoom(string roomId)
        {
            return _pokerServiceClient.GetRoom(roomId);
        }
    }
}