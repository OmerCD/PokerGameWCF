using MongoCRUD.Interfaces;

namespace PokerLibrary
{
    public class Player : DbObject
    {
        public string Name { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}