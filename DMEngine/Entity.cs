using DMEngine.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMEngine
{
    public class Entity : IDataLinkable
    {
        public string name;
        public EntityGraph graph;

        // This list is only used by entity to pass along methods for the components and
        // to return the component within the list.
        // Each component in an entity must have an AddComponent call OnGameStart
        List<Component> components = new List<Component>();

        #region Behaviors
        public virtual void OnInitialize() { }
        public void Initialize()
        {
            OnInitialize();
        }

        public virtual void OnPostInitialize() { }
        public void PostInitialize()
        {
            OnPostInitialize();

            foreach (Component component in components)
            {
                component.PostInitialize();
            }
        }

        public virtual void OnTick(double deltaTime) { }
        public void Tick(double deltaTime)
        {
            foreach (Component component in components)
            {
                component.OnTick(deltaTime);
            }

            OnTick(deltaTime);
        }

        public virtual void OnLink(IDataLinker linker) { }
        public void Link(IDataLinker linker)
        {
            name = linker.LinkString("Name", name);

            OnLink(linker);
        }
        #endregion

        public virtual void OnDestroy() { }
        public void Destroy()
        {
            foreach (Component component in components)
            {
                component.Destroy();
            }
        }

        public T Component<T>() where T : Component
        {
            T toReturn = null;
            foreach (var component in components)
            {
                try
                {
                    var s = (T)component;
                    toReturn = s;
                }
                catch (InvalidCastException)
                {
                    continue;
                }
            }
            return toReturn;
        }

        // Must use this on GameStart if you want it to be on entity by default.
        // Keep private because this should only be used by the entity itself.
        // No adding components dynamically!
        public T AddComponent<T>() where T : Component, new()
        {
            T component = new T();
            return AddComponent(component);
        }

        public T AddComponent<T>(T component) where T : Component
        {
            component.entity = this;
            components.Add(component);

            component.Initialize();
            return component;
        }
    }
}
