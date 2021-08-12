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
    class Panel : Component
    {
        public CharacterMap map;

        public Panel(CharacterMap map)
        {
            this.map = map;
        }

        public override void OnLink(IDataLinker linker)
        {
            // link panel
        }

        public override void OnPostInitialize()
        {
            DrawCap(0);
            for(int y = 1; y < map.transform.rect.size.y - 1; y++)
            {
                DrawSide(y);
            }
            DrawCap(map.transform.rect.size.y - 1);
        }

        public void DrawCap(int y)
        {
            for (int x = 0; x < map.transform.rect.size.x; x++)
            {
                map.Print(new Character('#'), new Vector2(x, y));
            }
        }

        public void DrawSide(int y)
        {
            map.Print(new Character('#'), new Vector2(0, y));
            map.Print(new Character('#'), new Vector2(map.transform.rect.size.x - 1, y));
        }
    }
}
