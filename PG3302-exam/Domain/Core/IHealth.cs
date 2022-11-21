using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public interface IHealth
    {
        bool IsDestroyed { get; }
        int Health { get; set; }

        void Destroy();
    }
}
