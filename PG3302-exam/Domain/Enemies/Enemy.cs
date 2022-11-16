using Domain.Data;
using Domain.Core;

namespace Domain.Enemies
{
    public abstract class Enemy : IHittable, IMovable
    {
        public abstract Point Pos { get; set; }
        public abstract Sprite ActiveSprite { get; set; }
        public abstract bool IsDead { get; }
        public abstract int Speed { get; set; }
        public abstract Point MoveDir { get; set; }

        public abstract Dimension Size { get; }
        public abstract IHittable.HitMask Mask { get; set; }

        public abstract Bullet Attack();

        public abstract void Damage();

        public abstract bool Hit(IHittable hittable);
    }
}

