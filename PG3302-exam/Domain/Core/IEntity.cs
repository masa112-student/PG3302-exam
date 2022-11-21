using Domain.Data;

namespace Domain.Core
{
    /// <summary>
    /// The top level Interface for all things that can exists in the game
    /// 
    /// Size is the 2D rectangular size of the entity
    /// Pos is the 2D X, Y position of the entity
    /// 
    /// </summary>
    public interface IEntity
    {
        Dimension Size { get; }

        Point Pos { get; set; }
    }
}
