using System.Drawing;

namespace Game.Entity
{
    public class Entity
    {
        public string Name { get; set; }
        public int Hp { get; set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        public int IdleFrames;
        public int WalkFrames;
        public int AttackFrames;
        public int DeathFrames;

        public Image Sprite;
        public Entity(string name, int hp, int posX, int posY, int idleFrames, int walkFrames, int attackFrames, int deathFrames, Image sprite) { 
            this.Name = name;
            this.Hp = hp;
            this.PosX = posX;
            this.PosY = posY;

            this.IdleFrames = idleFrames;
            this.WalkFrames = walkFrames;
            this.AttackFrames = attackFrames;
            this.DeathFrames = deathFrames;
            this.Sprite = sprite;
        }
    }
}
