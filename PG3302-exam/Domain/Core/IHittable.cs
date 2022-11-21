namespace Domain.Core
{
    /// <summary>
    /// Interface for adding hit detection to entities.
    /// Entites will only collide with other entities that have the same mask.
    /// 
    /// Mask returns the entitys mask
    /// Hit() returns true if the other entity has the same mask and it's dimensions are overlapping
    /// </summary>
    public interface IHittable : IEntity {
        enum HitMask {
            Player,
            Enemy
        }

        HitMask Mask {get; set;}

        bool Hit(IHittable other);
    }
}
