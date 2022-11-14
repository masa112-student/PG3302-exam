using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Data;

namespace Domain.Core
{
    public interface IEntity
    {
        Dimension Size { get; }

        Point Pos { get; set; }
    }
}
