using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class BaseEnemy : IEnemy, IHittable 
    {
        private Sprite _activeSprite;
        private bool _isDead;

        EnemyMovement? _enemyMovement;

        public Point Pos { get; set; }
        public Sprite ActiveSprite {
            get {
                return _activeSprite;
            }
            set {
                if (value != null) {
                    _activeSprite = value;
                    _activeSprite.Pos = Pos;
                }
            }
        }

        public bool IsDead {
            get => _isDead;
            internal set {
                _isDead = value;
                
                if(_isDead) {
                    ActiveSprite = Sprite.CreateBlankFromSprite(ActiveSprite);
                }
            } 
        }

        public BaseEnemy() {
            ActiveSprite = new Sprite();
            Move();
        }
        public int Speed() => 200;

        public Bullet Attack() {
            return new Bullet(0, 0, 0);
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

