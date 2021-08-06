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

        public void Serialize()
        {
            database.SerializeToFile(databaseFilename, this);
        }

        public void Deserialize()
        {
            database.DeserializeFromFile(databaseFilename, this);
        }

        public void OnGameStart()
        {
            foreach(EntityGraph graph in graphs)
            {
                graph.OnGameStart();
            }
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

        public void OnLink(IDataLinker linker)
        {

        }

        public void Tick(double deltaTime)
        {
            foreach(EntityGraph graph in graphs)
            {
                graph.Tick(deltaTime);
            }
        }
    }
}
