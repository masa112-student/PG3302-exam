using Domain.Data;

namespace Domain.Core
{
    /// <summary>
    /// Inteface for all movable entities
    /// 
    /// Speed returns the entities speed
    /// MoveDir returns the current X,Y coords the entity is heading
    /// </summary>
    public interface IMovable : IEntity
    {
        int Speed { get; set; }

        Point MoveDir { get; set; }
    }
}
