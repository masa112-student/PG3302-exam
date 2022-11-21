using Domain.Data;
using Domain.Core;

namespace Domain.Enemies
{
    /// <summary>
    /// Abstract blueprint class for enemies
    /// </summary>
    public abstract class Enemy : IHittable, IMovable
    {
        // Normal properties made virtual for subclasses to extend
        public virtual Point Pos { get; set; }
        public virtual bool IsDead { get; protected set; }
        public virtual int Speed { get; set; }
        public virtual int Value { get; protected set; }
        public virtual Point MoveDir { get; set; }
        public virtual int Health { get; set; }
        public virtual IHittable.HitMask Mask { get; set; }
        
        // Properties that must be implemented by the sublclass
        // either because they have no setter, or the return type is non nullable
        public abstract Sprite ActiveSprite { get; set; }
        public abstract bool CanAttack { get; }
        public abstract bool ShouldAttack { get; }
        public abstract Dimension Size { get; }

        public abstract Bullet Attack();
        public abstract void Kill();
        public abstract bool Hit(IHittable hittable);
    }
}

