using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace View
{
    internal class BaseEnemy
    {
        public Point pos { get; set; }

        public void Move() { }
        public Sprite GetSprite() {
            return new Sprite();
        }
        public Bullet Attack() {
            return new Bullet(0, 0);
        }
    }
}
