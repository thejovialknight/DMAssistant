using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMEngine.Transform;

namespace DMEngine.CharacterMapRenderer
{
    public class CharacterDifference
    {
        public Character newCharacter = new Character();
        public Vector2 position = new Vector2();

        public CharacterDifference(Character character, Vector2 pos)
        {
            newCharacter = character;
            position = pos;
        }
    }
}
