using Game.Entity;
using Game.Models;

namespace Client
{
    public partial class Form1 : Form
    {
        public Image heroSprites;
        public Entity player;
        public Form1()
        {
            InitializeComponent();

            timer1.Interval = 10;
            timer1.Tick += new EventHandler(Update);

            KeyDown += new KeyEventHandler(OnPress);
            Run();
        }
        public void OnPress(object sender, KeyEventArgs e) {

            switch (e.KeyCode) {
                case Keys.W:
                    player.Move(0, -1);
                    break;                
                case Keys.S:
                    player.Move(0, 1);
                    break;                
                case Keys.A:
                    player.Move(-1, 0);
                    break;                
                case Keys.D:
                    player.Move(1, 0);
                    break;
            }
        }

        public void Run()
        {
            heroSprites = new Bitmap("C:\\Users\\main\\source\\repos\\Game\\Client\\idle_down.jpg");

            player = new(100, 100, Hero.IdleFrames, Hero.WalkFrames, Hero.AttackFrames, Hero.DeathFrames, heroSprites);
            timer1.Start();
        }

        public void Update(object sender, EventArgs e) 
        {
            Invalidate();
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(player.Sprite, new Rectangle(new Point(player.PosX, player.PosY), new Size(150, 150)), 0, 0, 150, 150, GraphicsUnit.Pixel);
        }
    }
}