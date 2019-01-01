using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using MongoCRUD;
using PokerLibrary;

namespace PokerGameService
{
    public static class RoomController
    {
        private static List<Room> _rooms;
        private static readonly Crud<Room> _crudRoom;
        private static byte _roomCount;

        static RoomController()
        {
            _crudRoom = new Crud<Room>();
            if (_crudRoom.Count > 0)
            {
                _rooms = _crudRoom.GetAll();
                _roomCount = (byte)_rooms.Select(x =>
                {
                    x.Players = new List<Player>();
                    x.PlayerReadyStatus = new ConcurrentDictionary<string, bool>();
                    return _crudRoom.Update(x._id, x);
                }).Count();
            }
            else
            {
                _rooms = new List<Room>();
                var room = new Room
                {
                    Name = "First Room",
                    MaxNumbers = 8,
                    MinNumbers = 3
                };
                CreateRoom(room);
            }
        }

        private static void CreateRoom(Room room)
        {
            _crudRoom.Insert(room);
            _rooms.Add(room);
        }
        public static List<Room> GetRooms()
        {
            _rooms = _crudRoom.GetAll();
            return _rooms;
        }

        public static Room GetRoom(string roomId)
        {
            return _crudRoom.GetOne(roomId);
        }

        public static Room FindRoom(Predicate<Room> matchConditions)
        {
            return _rooms.Find(matchConditions);
        }

        public static bool UpdateRoom(Room room)
        {
            return _crudRoom.Update(room._id, room);
        }
        public static Room RegisterToRoom(string playerName, string roomId)
        {
            var player = PlayerController.GetAllPlayers().FirstOrDefault(x => x.Name == playerName);
            var room = _crudRoom.GetOne(roomId);

            if (player != null && _rooms.Find(x => x._id == roomId) != null)
            {
                if (!room.Players.Contains(player))
                {
                    room.AddPlayer(player);

                    _crudRoom.Update(room._id, room);
                    RefreshRoomListForPlayers(room);
                    return room;
                }
            }

            return null;
        }

        private static void RefreshRoomListForPlayers(Room room)
        {
            foreach (var roomPlayer in room.Players)
            {
                PlayerController.PlayerList[roomPlayer.Name].RefreshRoomList(room._id);
            }
        }

        public static bool ExitFromRoom(string playerName, string roomId)
        {
            var player = PlayerController.GetAllPlayers().FirstOrDefault(x => x.Name == playerName);
            var room = _crudRoom.GetOne(roomId);

            if (player != null || _rooms.Find(x => x._id == roomId) != null)
            {
                if (room.Players.Contains(player))
                {
                    room.RemovePlayer(player._id);
                    _crudRoom.Update(room._id, room);
                    return true;
                }
            }

            return false;
        }

        public static void CheckReadyStatus(string roomId)
        {
            var room = _crudRoom.GetOne(roomId);
            if(room.MinNumbers > room.Players.Count) return;
            if (room.IsEverybodyReady == true)
            {
                foreach (var player in room.Players)
                {
                    PlayerController.PlayerList[player.Name].StartTheGame(roomId);
                }
            }
        }
    }
}
