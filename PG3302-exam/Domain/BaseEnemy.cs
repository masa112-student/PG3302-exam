using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BaseEnemy : IHittable
    {
        private Sprite activeSprite;
        private bool isDead;

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

        public BaseEnemy() {
            ActiveSprite = new Sprite();
        }
        public void Move() { }

        public Bullet Attack() {
            return new Bullet(0, 0, 0);
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
