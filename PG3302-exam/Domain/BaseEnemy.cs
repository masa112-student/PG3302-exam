using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    internal class BaseEnemy
    {
        private Sprite activeSprite;

        public Point pos { get; set; }
        public Sprite ActiveSprite { 
            get { 
                activeSprite.Pos = pos;
                return activeSprite;
            }
            set {
                if(value != null) 
                    activeSprite = value;
            }
        }

        public BaseEnemy() {
            ActiveSprite = new Sprite();
        }
        public void Move() { }

        public Bullet Attack() {
            return new Bullet(0, 0, 0);
        }
    }
}
