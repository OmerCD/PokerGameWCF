using System;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using PokerLibrary;

namespace PokerGameClient
{
    public partial class MainClientForm : Form
    {
        private readonly ClientGameOperations _gameOperations = new ClientGameOperations();

        private Room _currentRoom;
        private Player _player;
        public MainClientForm()
        {
            InitializeComponent();
            AcceptPokerCallBack.ClientForm = this;
            RefreshRoomList();
        }

        private async void RefreshRoomList()
        {
            var rooms = await _gameOperations.GetRoomsAsync();
            lock (lBGameRooms.Items)
            {
                lBGameRooms.Items.Clear();
                lBGameRooms.Items.AddRange(rooms);
                if (_currentRoom != null)
                {
                    _currentRoom = rooms.FirstOrDefault(x => x._id == _currentRoom._id);
                    lbRoomPlayers.Items.AddRange(_currentRoom?.Players.ToArray());
                }
            }

            lBGameRooms.SelectedIndex = 0;
        }

        private async void Login_Click(object sender, EventArgs e)
        {
            if (tBUserName.TextLength > 1)
            {
                lock (lBGameRooms.Items)
                {
                    _currentRoom = (Room)lBGameRooms.SelectedItem;
                }
                if (_currentRoom.MaxNumbers <= _currentRoom.Players.Count)
                {
                    MessageBox.Show("Room Capacity Reached");
                    return;
                }
                _player = _gameOperations.Register(tBUserName.Text);
                _currentRoom = await _gameOperations.JoinRoom(tBUserName.Text, _currentRoom._id);
                //RefreshPlayerList();
            }
        }

        public void RefreshPlayerList()
        {
            lock (lbRoomPlayers.Items)
            {
                lbRoomPlayers.Items.Clear();
                RefreshRoomList();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ((Action)(() => _gameOperations.TestConnection())).BeginInvoke(null, null);
        }
        private void Ready_Click(object sender, EventArgs e)
        {
            _gameOperations.SendReady(_player.Name, _currentRoom._id);
        }
    }
}
