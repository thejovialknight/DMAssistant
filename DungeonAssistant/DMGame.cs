using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMEngine;
using DMEngine.Database;
using DMEngine.CharacterMapRenderer;
using DMEngine.Input;

namespace DungeonAssistant
{
    class DMGame : Game
    {
        // Should be initialized first
        public CharacterRenderer renderer;
        public InputSystem input;

        // Graphs with entities
        public DisplayGraph display;
        public WorldGraph world;

        public override void OnInitialize()
        {
            // Initialized first. Perhaps try to make this not necessary. 
            renderer = AddGraph<CharacterRenderer>();
            input = AddGraph<InputSystem>();

            // Graphs with entities.
            display = AddGraph<DisplayGraph>();
            world = AddGraph<WorldGraph>();
        }

        public override void OnLink(IDataLinker linker)
        {
            display = linker.LinkObject("displayGraph", display);
            world = linker.LinkObject("worldGraph", world);
            renderer = linker.LinkObject("rendererGraph", renderer);
            input = linker.LinkObject("input", input);
        }
    }
}
