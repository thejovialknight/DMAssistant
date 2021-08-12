using DMEngine.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMEngine.CharacterMapRenderer
{
    public class CharacterColumn : IDataLinkable
    {
        public List<Character> characters = new List<Character>();

        public void Link(IDataLinker linker)
        {
            characters = linker.LinkObjectList("characters", characters);
        }
    }
}
