using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using MongoCRUD;
using PokerLibrary;

namespace PokerGameService
{
    public static class PlayerController
    {
        private static readonly Crud<Player> _crudPlayer;
        public static event Action<string> PlayerSendReady;

        private static readonly ConcurrentDictionary<string, IPokerClientCallBack> _playerList;


        static PlayerController()
        {
            _crudPlayer = new Crud<Player>();
            _playerList = new ConcurrentDictionary<string, IPokerClientCallBack>();
        }

        public static ConcurrentDictionary<string, IPokerClientCallBack> PlayerList => _playerList;

        public static Player RegisterPlayer(string playerName)
        {
            var current = _crudPlayer.GetAll().FirstOrDefault(x => x.Name == playerName);
            if (current == null)
            {
                var player = new Player
                {
                    Name = playerName
                };
                _playerList.TryAdd(playerName, OperationContext.Current.GetCallbackChannel<IPokerClientCallBack>());
                return _crudPlayer.Insert(player) ? player : null;
            }

            if (!_playerList.ContainsKey(playerName))
            {
                _playerList.TryAdd(playerName, OperationContext.Current.GetCallbackChannel<IPokerClientCallBack>());
            }
            return current;
        }

        public static List<Player> GetAllPlayers()
        {
            return _crudPlayer.GetAll();
        }

        public static void SendReady(string playerName, string roomId)
        {
            var player = _crudPlayer.GetAll().FirstOrDefault(x => x.Name == playerName);
            var room = RoomController.GetRoom(roomId);
            if (room != null)
            {
                if (player != null || RoomController.FindRoom(x => x._id == roomId) != null)
                {
                    if (room.Players.FirstOrDefault(x => x._id == player._id) != null)
                    {
                        room.PlayerReadyStatus[player._id] = true;
                        PlayerSendReady?.Invoke(roomId);
                        RoomController.UpdateRoom(room);
                        RoomController.CheckReadyStatus(roomId);
                    }
                }
            }
        }
    }
}
