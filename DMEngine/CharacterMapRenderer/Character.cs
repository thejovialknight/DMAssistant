using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMEngine.CharacterMapRenderer
{
    // Extended version of char with planned inclusion of color options and whatnot.
    public class Character
    {
        public char character = ' ';
        public ConsoleColor color = ConsoleColor.White;

        public Character()
        {

        }

        public Character(char character)
        {
            this.character = character;
        }

        public Character(char character, ConsoleColor color)
        {
            this.character = character;
            this.color = color;
        }
    }
}
