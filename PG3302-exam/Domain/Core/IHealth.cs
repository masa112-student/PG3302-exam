using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Core
{
    public interface IHealth
    {
        int Health { get; set; }

        void Destroy();
    }
}
