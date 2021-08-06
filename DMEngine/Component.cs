using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMEngine
{
    public abstract class Component
    {
        public Entity entity;

        public abstract void OnGameStart();
        public abstract void OnStart(double deltaTime);
        public abstract void OnTick(double deltaTime);
        public abstract void OnDestroy(double deltaTime);
    }
}
