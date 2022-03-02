using Game.Entity;
using Game.Models;

namespace Client
{
    public partial class Form1 : Form
    {
        public Image heroSprites;

        public Form1()
        {
            InitializeComponent();
        }


        public void Run()
        {
#pragma warning disable CS8602 // –азыменование веро€тной пустой ссылки.
            heroSprites = new Bitmap(Path.Combine(new DirectoryInfo(Directory.GetCurrentDirectory()).Parent.Parent.FullName.ToString(), "Sprites\\PlayerWalk\\walk down.png"));
#pragma warning restore CS8602 // –азыменование веро€тной пустой ссылки.

            Entity player = new(100, 100, Hero.IdleFrames, Hero.WalkFrames, Hero.AttackFrames, Hero.DeathFrames, heroSprites);
        }

        private void OnPaint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImage(heroSprites, new PointF(100, 100));
        }
    }
}