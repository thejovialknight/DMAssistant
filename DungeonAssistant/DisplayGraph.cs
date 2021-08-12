using DMEngine;
using DMEngine.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAssistant
{
    class DisplayGraph : EntityGraph
    {
        ConsoleBufferDisplay consoleBufferDisplay;


        public override void OnInitialize()
        {
            consoleBufferDisplay = CreateEntity<ConsoleBufferDisplay>();
        }

        public override void OnLink(IDataLinker linker)
        {
            consoleBufferDisplay = linker.LinkObject("consoleBufferDisplay", consoleBufferDisplay);
        }

        public override void OnPostInitialize()
        {

        }

        public override void OnTick(double deltaTime)
        {

        }
    }
}
