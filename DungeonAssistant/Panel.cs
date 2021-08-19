using DMEngine;
using DMEngine.CharacterMapRenderer;
using DMEngine.Database;
using DMEngine.CharacterTransform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAssistant
{
    class Panel : Entity
    {
        public CharacterMap map;
        public RectTransform transform;

        public Panel()
        {
            transform = AddComponent(new RectTransform());
        }

        public Panel(Rect rect)
        {
            transform = AddComponent(new RectTransform(rect));
        }
        public Panel(int xPos, int yPos, int xSize, int ySize)
        {
            Rect rect = new Rect(xPos, yPos, xSize, ySize);
            transform = AddComponent(new RectTransform(rect));
        }


        public Panel(int xPos, int yPos, int xSize, int ySize, RectTransform parent)
        {
            Rect rect = new Rect(xPos, yPos, xSize, ySize);
            transform = AddComponent(new RectTransform(rect, parent));
        }

        public Panel(Rect rect, RectTransform parent)
        {
            transform = AddComponent(new RectTransform(rect, parent));
        }

        public override void OnLink(IDataLinker linker)
        {
            // link panel
        }

        public override void OnInitialize()
        {
            // transform ??= blah bla
            map = AddComponent(new CharacterMap(transform));
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

        public static Rect ChildRect(Rect parentRect)
        {

        }
    }
}
