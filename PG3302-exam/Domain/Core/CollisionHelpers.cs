namespace Domain.Core
{
    internal class CollisionHelpers
    {

        public static bool AABBHit(IHittable a, IHittable b) {
            if(a.Mask != b.Mask)
                return false;

            return a.Pos.X < b.Pos.X + b.Size.Width &&
                a.Pos.Y < b.Pos.Y + b.Size.Height &&
                a.Pos.X + a.Size.Width > b.Pos.X &&
                a.Pos.Y + a.Size.Height > b.Pos.Y;
        }
    }
}
