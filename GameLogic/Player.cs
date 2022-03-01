namespace Game.Player
{
    public class Player
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }
        public Player(string Name, int Hp, int PosX, int PosY) { 
            this.Name = Name;
            this.Hp = Hp;
            this.PosX = PosX;
            this.PosY = PosY;
        }
    }
}
