﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public interface IMovable : IEntity {
        int Speed { get; set; }
        
        Point MoveDir { get; set; }

    }
}
