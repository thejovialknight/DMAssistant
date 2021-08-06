using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMEngine.Transform;

namespace DMEngine.CharacterMapRenderer
{
    // Interface for the actual character map.
    public class CharacterMap
    {
        public Rect rect;
        public Character[,] map;
        public List<CharacterDifference> differences = new List<CharacterDifference>();
        public bool isSizeOrPositionDifferent = true;

        public CharacterMap(Rect rect)
        {
            this.rect = rect;
            map = new Character[rect.size.x, rect.size.y];
        }

        public void ClearDifferences()
        {
            differences.Clear();
        }
    }
}
