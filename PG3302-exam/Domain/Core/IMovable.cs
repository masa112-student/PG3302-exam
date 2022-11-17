using Domain.Data;

namespace Domain.Core
{
    public interface IMovable : IEntity
    {
        int Speed { get; set; }

        Point MoveDir { get; set; }

    }
}
