namespace Domain.Core
{
    /// <summary>
    /// A util class for containing collision logic
    /// </summary>
    internal class CollisionHelpers
    {
        public static bool AABBHit(IHittable a, IHittable? b) {
            if (b == null) return false;

            if(a.Mask != b.Mask)
                return false;

            return a.Pos.X < b.Pos.X + b.Size.Width &&
                a.Pos.Y < b.Pos.Y + b.Size.Height &&
                a.Pos.X + a.Size.Width > b.Pos.X &&
                a.Pos.Y + a.Size.Height > b.Pos.Y;
        }
    }
}
