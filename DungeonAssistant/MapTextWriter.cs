using DMEngine;
using DMEngine.CharacterMapRenderer;
using DMEngine.Database;
using DMEngine.Transform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAssistant
{
    class MapTextWriter : Component
    {
        public string text;
        public int cursorPosition;
        public Vector2 rootPosition;
        public CharacterMap map;

        public override void OnLink(IDataLinker linker)
        {
            text = linker.LinkString("text", text);
            cursorPosition = linker.LinkInt("cursorPosition", cursorPosition);
            rootPosition = linker.LinkObject("rootPosition", rootPosition);
            map = linker.LinkObject("map", map);
        }
    }
}
