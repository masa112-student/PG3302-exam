namespace Domain.Enemies
{
    public abstract class Enemy : IHittable, IMovable
    {
        public abstract Point Pos { get; set; }
        public abstract Sprite ActiveSprite { get; set; }
        public abstract bool IsDead { get; set; }
        public abstract int Speed { get; set; }
        public abstract Point MoveDir { get; set; }

        public abstract Dimension Size { get; }

        public abstract void Move(Point direction);

        public abstract Bullet Attack();

        public abstract bool Hit(IHittable hittable);
    }
}

