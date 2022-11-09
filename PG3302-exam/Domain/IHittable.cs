namespace Domain
{
    public interface IHittable
    {
        enum Team
        {
            Player,
            Enemy
        }

        Point GetPos();
        Dimension GetDimension();

        bool Hit(IHittable hittable);
    }
}
