using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Game.NetworkMessages
{
    internal class Player
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Player(string name, int hp, int x, int y) { 
            this.Name = name;
            this.Hp = hp;
            this.X = x;
            this.Y = y;
        }

    }
}
