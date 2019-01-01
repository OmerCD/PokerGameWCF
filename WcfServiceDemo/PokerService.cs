using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using MongoCRUD;
using PokerLibrary;

namespace PokerGameService
{
    [ServiceBehavior(ConcurrencyMode = ConcurrencyMode.Multiple, InstanceContextMode = InstanceContextMode.Single)]

    public class PokerService : IPokerService
    {
        public PokerService()
        {
            MongoDbConnection.InitializeAndStartConnection(databaseName: "Poker", serverIP: "192.168.1.67");
            PlayerController.PlayerSendReady += CheckGameStart;
        }
        private void CheckGameStart(string roomId)
        {
            var client = OperationContext.Current.GetCallbackChannel<IPokerClientCallBack>();
            client.StartTheGame(roomId);
        }

        public List<Room> GetRooms()
        {
            return RoomController.GetRooms();
        }

        public Room RegisterToRoom(string playerName, string roomId)
        {
            var room = RoomController.RegisterToRoom(playerName, roomId);
            //PlayerController.PlayerList[playerName].RefreshRoomList(roomId);
            //OperationContext.Current.GetCallbackChannel<IPokerClientCallBack>().StartTheGame("asdasd");
            return room;
        }

        public Player RegisterPlayer(string playerName)
        {
            return PlayerController.RegisterPlayer(playerName);
        }

        public bool ExitFromRoom(string playerName, string roomId)
        {
            return RoomController.ExitFromRoom(playerName, roomId);
        }

        public void SendReady(string playerName, string roomId)
        {
            PlayerController.SendReady(playerName, roomId);
        }

        public bool TestConnection()
        {
            var x = OperationContext.Current.GetCallbackChannel<IPokerClientCallBack>();
            x.StartTheGame("");
            return true;
        }

        public Room GetRoom(string roomId)
        {
            return RoomController.GetRoom(roomId);
        }
    }
}
