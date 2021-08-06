using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMEngine;
using DMEngine.Database;
using DMEngine.Time;

namespace DMAssistant
{
    class Program
    {
        static void Main(string[] args) 
        {
            JsonDatabase database = new JsonDatabase();

            DungeonAssistant game = new DungeonAssistant();
            game.SetDatabase(database, "Data.json");

            Time time = new Time();

            game.OnGameStart();
            while(true)
            {
                game.Tick(time.GetDeltaTime());
                time.SetLastTime();
            }
        }
    }
}
