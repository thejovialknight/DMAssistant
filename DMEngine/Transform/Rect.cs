using DMEngine.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMEngine.Transform
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

        public void Link(IDataLinker linker)
        {
            position = linker.LinkObject("Position", position);
            size = linker.LinkObject("Size", size);
        }
    }
}
