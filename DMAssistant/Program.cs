using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMEngine;

namespace DMAssistant
{
    class Program
    {
        static void Main(string[] args) 
        {
            JsonDatabase database = new JsonDatabase();
            DungeonAssistant game = new DungeonAssistant();
            game.database = database;
            Time time = new Time();

            while(true)
            {
                game.Tick(time.GetDeltaTime());
                time.SetLastTime();
            }
        }
    }
}
