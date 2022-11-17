using Domain.Data;

namespace Domain.Core
{
    public interface IEntity
    {
        Dimension Size { get; }

        Point Pos { get; set; }
    }
}
