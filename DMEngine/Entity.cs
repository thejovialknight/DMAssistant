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

        // Runs whether the scene is open or not
        public void OnGameStart()
        {
            foreach(Component component in components)
            {
                component.OnGameStart();
            }
        }

        public void OnStart(double deltaTime)
        {
            foreach (Component component in components)
            {
                component.OnStart(deltaTime);
            }
        }

        public void OnTick(double deltaTime)
        {
            foreach (Component component in components)
            {
                component.OnTick(deltaTime);
            }
        }

        public void OnDestroy(double deltaTime)
        {
            foreach (Component component in components)
            {
                component.OnDestroy(deltaTime);
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
        T AddComponent<T>() where T : Component, new()
        {
            T component = new T();
            component.entity = this;
            components.Add(component);
            return component;
        }

        // Base must be called to link name! (maybe add tags eventually?)
        public void OnLink(IDataLinker linker)
        {
            name = linker.LinkString("Name", name);
        }
    }
}
