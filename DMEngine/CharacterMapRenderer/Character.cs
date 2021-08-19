using DMEngine.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMEngine.CharacterMapRenderer
{
    // Extended version of char with planned inclusion of color options and whatnot.
    public class Character : IDataLinkable
    {
        public char character = ' ';
        string color = "White";

        static Dictionary<string, ConsoleColor> colorStringPair = new Dictionary<string, ConsoleColor>();

        public Character()
        {
            this.color = "White";
            SetupColorPairs();
        }

        public Character(char character)
        {
            this.color = "White";
            this.character = character;
            SetupColorPairs();
        }

        public Character(char character, string color)
        {
            this.character = character;
            this.color = color;
            SetupColorPairs();
        }

        public void SetColor(string color)
        {
            this.color = color;
        }

        public ConsoleColor Color()
        {
            if (colorStringPair.ContainsKey(color))
            {
                return colorStringPair[color];
            }

            return ConsoleColor.White;
        }

        public void SetupColorPairs()
        {
            if(colorStringPair.Count <= 0)
            {
                colorStringPair.Add("Black", ConsoleColor.Black);
                colorStringPair.Add("Blue", ConsoleColor.Blue);
                colorStringPair.Add("Cyan", ConsoleColor.Cyan);
                colorStringPair.Add("DarkBlue", ConsoleColor.DarkBlue);
                colorStringPair.Add("DarkCyan", ConsoleColor.DarkCyan);
                colorStringPair.Add("DarkGray", ConsoleColor.DarkGray);
                colorStringPair.Add("DarkGreen", ConsoleColor.DarkGreen);
                colorStringPair.Add("DarkMagenta", ConsoleColor.DarkMagenta);
                colorStringPair.Add("DarkRed", ConsoleColor.DarkRed);
                colorStringPair.Add("DarkYellow", ConsoleColor.DarkYellow);
                colorStringPair.Add("Gray", ConsoleColor.Gray);
                colorStringPair.Add("Green", ConsoleColor.Green);
                colorStringPair.Add("Magenta", ConsoleColor.Magenta);
                colorStringPair.Add("Red", ConsoleColor.Red);
                colorStringPair.Add("White", ConsoleColor.White);
                colorStringPair.Add("Yellow", ConsoleColor.Yellow);
            }
        }

        public void Link(IDataLinker linker)
        {
            character = linker.LinkString("character", character.ToString())[0];
            color = linker.LinkString("color", color);
        }

        public virtual bool Equals(Character other)
        {
            if(other.character != character || other.color != color)
            {
                return false;
            }

            return true;
        }
    }
}
