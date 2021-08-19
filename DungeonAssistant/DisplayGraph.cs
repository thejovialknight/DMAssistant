using DMEngine;
using DMEngine.Database;
using DMEngine.CharacterTransform;
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
        Panel consoleBufferPanel;

        public override void OnInitialize()
        {
            consoleBufferPanel = CreateEntity(new Panel(5, 5, 20, 10));
            consoleBufferDisplay = CreateEntity(new ConsoleBufferDisplay(consoleBufferPanel.transform));
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
