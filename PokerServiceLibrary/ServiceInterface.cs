using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;

namespace PokerLibrary
{
    [ServiceContract(CallbackContract = typeof(IPokerClientCallBack))]
    public interface IPokerService
    {
        [OperationContract]
        List<Room> GetRooms();

        [OperationContract]
        Room RegisterToRoom(string playerName, string roomId);

        [OperationContract]
        Player RegisterPlayer(string playerName);

        [OperationContract]
        bool ExitFromRoom(string playerName, string roomId);

        [OperationContract]
        void SendReady(string playerName, string roomId);

        [OperationContract]
        bool TestConnection();

        [OperationContract]
        Room GetRoom(string roomId);

    }

    [ServiceContract]
    public interface IPokerClientCallBack
    {
        [OperationContract(IsOneWay = true)]
        void StartTheGame(string roomId);

        [OperationContract(IsOneWay = true)]
        void RefreshRoomList(string roomId);

        [OperationContract(IsOneWay = true)]
        void PlayerReadyStatusChanged(string playerName, bool status);
    }
}
