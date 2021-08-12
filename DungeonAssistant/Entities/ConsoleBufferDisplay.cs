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
    class ConsoleBufferDisplay : Entity
    {
        RectTransform transform;
        CharacterMap map;
        Panel panel;

        public override void OnInitialize()
        {
            transform = AddComponent(new RectTransform(new Rect(new Vector2(2, 2), new Vector2(10, 10)), null));
            map = AddComponent(new CharacterMap(transform));
            panel = AddComponent(new Panel(map));
        }

        public override void OnLink(IDataLinker linker)
        {
            // link buffer entries
        }
    }
}
