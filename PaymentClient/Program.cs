using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using PaymentClient.PokerGameServiceReference;

namespace PaymentClient
{
    public class ProcessPayment
    {
        PokerServiceClient _op = new PokerServiceClient(new InstanceContext(new AcceptCallBack()));

        public Room[] GetRooms()
        {
            return _op.GetRooms();
        }

        //public bool Register(string name)
        //{
        //    return _op.RegisterPlayer(name);
        //}

        //public bool JoinRoom(string name, string roomId)
        //{
        //    return _op.RegisterToRoom(name, roomId);
        //}

        public void SendReady(string name, string roomId)
        {
            _op.SendReady(name, roomId);
        }
    }
    public class AcceptCallBack:IPokerServiceCallback
    {
        public void StartTheGame(string roomId)
        {
            Console.WriteLine("Game Started for room :"+ roomId);
        }

        public void RefreshRoomList(string roomId)
        {
            throw new NotImplementedException();
        }
    }
    class Program
    {
        public void Message()
        {
            Console.Write("Message");
        }
        static void Main(string[] args)
        {
            var pp = new ProcessPayment();
            var rooms = pp.GetRooms();
                        var players = rooms[0].Players;
            pp.SendReady("Ömer",rooms[0]._id);
        }
    }
}
