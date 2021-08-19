using DMEngine;
using DMEngine.CharacterMapRenderer;
using DMEngine.Database;
using DMEngine.Input;
using DMEngine.CharacterTransform;
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
        MapTextWriter mapTextWriter;

        public ConsoleBufferDisplay()
        {
            transform = AddComponent(new RectTransform());
        }

        public ConsoleBufferDisplay(Rect rect)
        {
            transform = AddComponent(new RectTransform(rect));
        }

        public ConsoleBufferDisplay(RectTransform parent)
        {
            Rect rect = new Rect(parent.rect.position.x + 1, parent.rect.position.y + 1, parent.rect.size.x - 2, parent.rect.size.y - 2);
            transform = AddComponent(new RectTransform(rect, parent));
        }

        public override void OnInitialize()
        {
            map = AddComponent(new CharacterMap(transform));
            mapTextWriter = AddComponent(new MapTextWriter(map));
        }

        public override void OnLink(IDataLinker linker)
        {
            // link buffer entries
        }
    }
}
