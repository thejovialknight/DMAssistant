using DMEngine.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMEngine
{
    public class Component : IDataLinkable
    {
        public Entity entity;

        public virtual void OnInitialize() { }
        public void Initialize()
        {
            OnInitialize();
        }

        public virtual void OnPostInitialize() { }
        public void PostInitialize()
        {
            OnPostInitialize();
        }

        public virtual void OnTick(double deltaTime) { }
        public void Tick(double deltaTime)
        {
            OnTick(deltaTime);
        }

        public virtual void OnDestroy() { }
        public void Destroy()
        {
            OnDestroy();
        }

        public virtual void OnLink(IDataLinker linker) { }
        public void Link(IDataLinker linker)
        {
            OnLink(linker);
        }
    }
}
