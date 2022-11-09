using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BaseEnemy : IHittable, IEnemy
    {
        private Sprite activeSprite;
        private bool isDead;
        EnemyMovement? _enemyMovement;

        public int XPos { get => _enemyMovement.XPos; }
        public int YPos { get => _enemyMovement.YPos; }

        public int Speed() => 200;

        public BaseEnemy()
        {
            ActiveSprite = new Sprite();
            Move();
        }

        public Point Pos { get; set; }
        public Sprite ActiveSprite {
            get {
                return activeSprite;
            }
            set {
                if (value != null) {
                    activeSprite = value;
                    activeSprite.Pos = Pos;
                }
            }
        }

        public bool IsDead { get => isDead; internal set { isDead = value;  Array.Fill(ActiveSprite.ColorData, Sprite.Color.Red); } }

        public Bullet Attack() {
            return new Bullet(0, 0, 0);
        }

        public void Draw()
        {
            Console.SetCursorPosition(XPos, YPos);
            Console.Write("X");
        }

        public EnemyMovement Move()
        {
            _enemyMovement = new EnemyMovement(Speed());
            return _enemyMovement;
        }

        public Point GetPos() {
            return Pos;
        }

        public bool Hit(IHittable hittable) {
            Point otherP = hittable.GetPos();
            Dimension otherSize = hittable.GetDimension();
            Dimension size = GetDimension();

            return Pos.X < (otherP.X + otherSize.Width) &&
                Pos.Y < (otherP.Y + otherSize.Height) &&
                (Pos.X + size.Width) > otherP.X &&
                (Pos.Y + size.Height) > otherP.Y;
        }

        public Dimension GetDimension() {
            return ActiveSprite.Size;
        }
    }
}

