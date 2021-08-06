using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMEngine.Time
{
    public interface ITickable
    {
        void Tick(double deltaTime);
    }
}
