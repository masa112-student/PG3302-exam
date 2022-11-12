namespace Domain.Enemies
{
    public abstract class Enemy : IHittable
    {
        public abstract Point Pos { get; set; }
        public abstract Sprite ActiveSprite { get; set; }
        public abstract bool IsDead { get; set; }
        public abstract int Speed { get; set; }
        public abstract int MovementDir { get; set; }

        public abstract void Move(Point direction);

        public abstract Bullet Attack();

        public abstract Point GetPos();

        public abstract Dimension GetDimension();

        public abstract bool Hit(IHittable hittable);
    }
}

