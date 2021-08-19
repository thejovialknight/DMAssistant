using DMEngine.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMEngine
{
    public partial class EntityGraph : IDataLinkable
    {
        public string name = "MySceneName";
        public bool isOpen = false;
        List<Entity> entities = new List<Entity>();
        public Game game;

        #region Behaviors
        public virtual void OnInitialize() { }
        public void Initialize ()
        {
            OnInitialize();
        }

        public virtual void OnPostInitialize() { }
        public void PostInitialize()
        {
            OnPostInitialize();

            foreach (Entity entity in entities)
            {
                entity.PostInitialize();
            }
        }

        public virtual void OnTick(double deltaTime) { }
        public void Tick(double deltaTime)
        {
            OnTick(deltaTime);

            foreach (Entity entity in entities)
            {
                entity.OnTick(deltaTime);
            }
        }

        public virtual void OnLink(IDataLinker linker) { }
        public void Link(IDataLinker linker)
        {
            name = linker.LinkString("Name", name);
            isOpen = linker.LinkBool("IsOpen", isOpen);

            OnLink(linker);
        }
        #endregion

        // Must be added similar to AddComponent<> being required for Entities on OnGameStart
        public T CreateEntity<T>() where T : Entity, new()
        {
            T entity = new T();
            return CreateEntity(entity);
        }

        public T CreateEntity<T>(T entity) where T : Entity, new()
        {
            entity.graph = this;
            entities.Add(entity);

            entity.Initialize();
            RaiseOnEntityCreated(entity);
            return entity;
        }

        public T Entity<T>() where T : Entity
        {
            T toReturn = null;
            foreach (var entity in entities)
            {
                try
                {
                    var s = (T)entity;
                    toReturn = s;
                }
                catch (InvalidCastException)
                {
                    continue;
                }
            }
            return toReturn;
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

        #region Events

        public delegate void OnEntityCreated(Entity entity);
        public event OnEntityCreated onEntityCreated;

        public void RaiseOnEntityCreated(Entity entity)
        {
            onEntityCreated?.Invoke(entity);
            game.RaiseOnEntityCreated(entity, this);
        }

        public delegate void OnEntityDestroyed(Entity entity);
        public event OnEntityDestroyed onEntityDestroyed;

        public void RaiseOnEntityDestroyed(Entity entity)
        {
            onEntityCreated?.Invoke(entity);
        }

        #endregion
    }
}
