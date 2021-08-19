using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMEngine.Database;
using DMEngine.CharacterTransform;

namespace DMEngine.CharacterMapRenderer
{
    public class MapCharacter : IDataLinkable
    {
        public Character oldCharacter = new Character();
        public Character newCharacter = new Character();
        public Vector2 position = new Vector2();

        public MapCharacter(Character oldCharacter, Character character, Vector2 pos)
        {
            this.oldCharacter = oldCharacter;
            newCharacter = character;
            position = pos;
        }

        public void Link(IDataLinker linker)
        {
            oldCharacter = linker.LinkObject("oldCharacter", oldCharacter);
            newCharacter = linker.LinkObject("newCharacter", newCharacter);
            position = linker.LinkObject("position", position);
        }
    }
}
