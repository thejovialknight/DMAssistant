using DMEngine.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMEngine
{
    public class EntityGraph : IDataLinkable
    {
        public string name = "MySceneName";
        public bool isOpen = false;
        List<Entity> entities = new List<Entity>();

        public void OnGameStart()
        {
            foreach(Entity entity in entities)
            {
                entity.OnGameStart();
            }
        }

        // Must be added similar to AddComponent<> being required for Entities on OnGameStart
        public T AddEntity<T>() where T : Entity, new()
        {
            T entity = new T();
            entity.graph = this;
            entities.Add(entity);
            return entity;
        }

        public void Tick(double deltaTime)
        {
            foreach(Entity entity in entities)
            {
                entity.OnTick(deltaTime);
            }
        }

        // Returns the component T from every entity that has one
        public T[] ComponentsInEntities<T>() where T : Component
        {
            List<T> components = new List<T>();

            foreach(Entity entity in entities)
            {
                T component = entity.Component<T>();
                if (component != null)
                {
                    components.Add(component);
                }
            }

            return components.ToArray();
        }

        public void OnLink(IDataLinker linker)
        {
            name = linker.LinkString("Name", name);
            isOpen = linker.LinkBool("IsOpen", isOpen);
            entities = linker.LinkObjectList("Entities", entities);
        }
    }
}
