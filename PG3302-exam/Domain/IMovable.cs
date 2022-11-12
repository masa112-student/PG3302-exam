using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IMovable {
        public int Speed { get; set; }
        public Point Pos { get; set; }
    }
}
