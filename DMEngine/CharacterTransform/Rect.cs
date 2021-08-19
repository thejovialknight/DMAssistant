using DMEngine.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMEngine.CharacterTransform
{
    public class Rect : IDataLinkable
    {
        public Vector2 position = new Vector2();
        public Vector2 size = new Vector2();

        public Rect()
        {

        }

        public Rect(Vector2 position, Vector2 size)
        {
            this.position = position;
            this.size = size;
        }

        public Rect(int xPos, int yPos, int xSize, int ySize)
        {
            position = new Vector2(xPos, yPos);
            size = new Vector2(xSize, ySize);
        }

        public void Link(IDataLinker linker)
        {
            position = linker.LinkObject("Position", position);
            size = linker.LinkObject("Size", size);
        }
    }
}
