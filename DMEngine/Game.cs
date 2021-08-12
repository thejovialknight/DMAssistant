using DMEngine.Database;
using DMEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMEngine.Time;

namespace DMEngine
{
    public class Game : IDataLinkable, ITickable
    {
        public IDatabase database;
        string databaseFilename;

        // All scenes, open or not
        List<EntityGraph> graphs = new List<EntityGraph>();

        public void SetDatabase(IDatabase database, string filename)
        {
            this.database = database;
            databaseFilename = filename;
        }

        // Must be added similar to AddComponent<> being required for Entities on OnGameStart
        public T AddGraph<T>() where T : EntityGraph, new()
        {
            T graph = new T();
            graph.game = this;
            graphs.Add(graph);

            graph.Initialize();
            return graph;
        }

        public void Serialize()
        {
            database.SerializeToFile(databaseFilename, this);
        }

        public void Deserialize()
        {
            database.DeserializeFromFile(databaseFilename, this);
        }

        public EntityGraph OpenScene(EntityGraph graph)
        {
            graph.isOpen = true;
            return graph;
        }

        public EntityGraph CloseScene(EntityGraph graph)
        {
            graph.isOpen = false;
            return graph;
        }

        public virtual void OnInitialize() { }
        public void Initialize()
        {
            OnInitialize();
            PostInitialize();
        }

        public virtual void OnPostInitialize() { }
        public void PostInitialize()
        {
            OnPostInitialize();

            foreach(EntityGraph graph in graphs)
            {
                graph.PostInitialize();
            }
        }

        public virtual void OnLink(IDataLinker linker) { }
        public void Link(IDataLinker linker)
        {
            OnLink(linker);
        }

        public virtual void OnTick(double deltaTime) { }
        public void Tick(double deltaTime)
        {
            foreach(EntityGraph graph in graphs)
            {
                graph.Tick(deltaTime);
            }

            OnTick(deltaTime);
        }

        #region Events

        public delegate void OnEntityCreated(Entity entity, EntityGraph graph);
        public event OnEntityCreated onEntityCreated;

        public void RaiseOnEntityCreated(Entity entity, EntityGraph graph)
        {
            onEntityCreated?.Invoke(entity, graph);
        }

        public delegate void OnEntityDestroyed(Entity entity, EntityGraph graph);
        public event OnEntityDestroyed onEntityDestroyed;

        public void RaiseOnEntityDestroyed(Entity entity, EntityGraph graph)
        {
            onEntityCreated?.Invoke(entity, graph);
        }

        #endregion
    }
}
