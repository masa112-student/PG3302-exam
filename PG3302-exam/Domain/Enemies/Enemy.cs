using Domain.Data;
using Domain.Core;

namespace Domain.Enemies
{
    /// <summary>
    /// Abstract blueprint class for enemies. This is used by both the basic enemy implemntation, and also the decorators
    /// </summary>
    public abstract class Enemy : IHittable, IMovable, IHealth
    {
        // Normal properties made virtual for subclasses to extend
        public virtual Point Pos { get; set; }
        public virtual Point MoveDir { get; set; }
        public virtual int Speed { get; set; }
        public virtual int Health { get; set; }
        public virtual bool IsDestroyed { get; }
        public virtual int Value { get; protected set; }
        public virtual IHittable.HitMask Mask { get; set; }
        
        // Properties that must be implemented by the sublclass
        // either because they have no setter, or the return type is non nullable
        public abstract Sprite ActiveSprite { get; set; }
        public abstract Dimension Size { get; }
        public abstract bool CanAttack { get; } // Is it allowed to attack (ex weapon cooldown)
        public abstract bool ShouldAttack { get; } // Should it (ex only attack if certain conditions are met, or random chance to attack)

        public abstract int AttackSpeedMs { get; }

        public abstract Bullet Attack();
        public abstract void Destroy();
        public abstract bool Hit(IHittable hittable);

    }
}

