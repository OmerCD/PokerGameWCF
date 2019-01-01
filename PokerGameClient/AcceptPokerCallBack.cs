using System;
using System.ServiceModel;
using PokerGameClient.PokerGameServiceReference;

namespace PokerGameClient
{
    [CallbackBehavior(ConcurrencyMode = ConcurrencyMode.Multiple)]
    public class AcceptPokerCallBack : IPokerServiceCallback
    {
        public static MainClientForm ClientForm;
        public void StartTheGame(string roomId)
        {
            Console.WriteLine("Game Started for room :" + roomId);
        }
        
        public void RefreshRoomList(string roomId)
        {
            ClientForm.RefreshPlayerList();
        }
    }
}