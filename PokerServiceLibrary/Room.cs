using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoCRUD.Interfaces;

namespace PokerLibrary
{
    public class Room : DbObject
    {
        public string Name { get; set; }
        public List<Player> Players { get; set; }
        public byte MaxNumbers { get; set; }
        public byte MinNumbers { get; set; }
        public byte Count => (byte)Players.Count;

        private ConcurrentDictionary<string, bool> _playerReadyStatus;

        public bool IsEverybodyReady
        {
            get
            {
                foreach (var playerReadyStatus in _playerReadyStatus)
                {
                    if (playerReadyStatus.Value == false)
                    {
                        return false;
                    }
                }

                return true;
            }
        }
        public ConcurrentDictionary<string, bool> PlayerReadyStatus
        {
            get => _playerReadyStatus;
            set { _playerReadyStatus = value; }
        }

        public Room(byte maxNumbers = 4)
        {
            MaxNumbers = maxNumbers;
            Players = new List<Player>(maxNumbers);
            PlayerReadyStatus = new ConcurrentDictionary<string, bool>();
        }

        public void AddPlayer(Player player)
        {
            Players.Add(player);
            PlayerReadyStatus[player._id] = false;
        }

        public void RemovePlayer(string playerName)
        {
            var player = Players.Find(x => x.Name == playerName);
            Players.Remove(player);
            PlayerReadyStatus.TryRemove(player._id,out _);
        }
        public Room()
        {
            MaxNumbers = 4;
            Players = new List<Player>(MaxNumbers);
            PlayerReadyStatus = new ConcurrentDictionary<string, bool>();
        }

        public override string ToString()
        {
            return Name + $" ({MaxNumbers}/{Players.Count})";
        }
    }
}
