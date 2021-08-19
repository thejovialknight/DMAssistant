using DMEngine.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMEngine.CharacterTransform
{
    public class Vector2 : IDataLinkable
    {
        public int x = 0;
        public int y = 0;

        public static Vector2 Zero { get { return new Vector2(0, 0); } }

        public Vector2()
        {
            
        }

        public Vector2(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public void Link(IDataLinker linker)
        {
            x = linker.LinkInt("X", x);
            y = linker.LinkInt("Y", y);
        }

        public static Vector2 operator +(Vector2 a, Vector2 b)
            => new Vector2(a.x + b.x, a.y + b.y);

        public static Vector2 operator -(Vector2 a, Vector2 b)
            => new Vector2(a.x - b.x, a.y - b.y);
    }
}
