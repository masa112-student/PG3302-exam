using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IHittable
    {
        enum Team {
            Player,
            Enemy
        }

        Point GetPos();
        Dimension GetDimension();
        
        bool Hit(IHittable hittable);
    }
}
