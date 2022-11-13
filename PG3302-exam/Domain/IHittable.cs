namespace Domain
{
    public interface IHittable : IEntity
    {
        enum Team
        {
            Player,
            Enemy
        }

        
        bool Hit(IHittable other);
    }
}
