namespace Domain.Core
{
    public interface IHittable : IEntity {
        enum HitMask {
            Player,
            Enemy
        }

        HitMask Mask {get; set;}

        bool Hit(IHittable other);
    }
}
