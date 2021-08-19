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
    class MapTextWriter : Component
    {
        public List<Character> characters = new List<Character>();
        public int cursorPosition = 0; // used to go back and forth during input, not the physical coordinate position, but index in characters
        public string currentColor = "White";

        public bool isWordWrapping = true;
        public Vector2 initialPrintPosition = Vector2.Zero;
        public int wordWrapXPosition = 0;

        public CharacterMap map;

        #region Constructors

        public MapTextWriter()
        {

        }

        public MapTextWriter(CharacterMap map)
        {
            this.map = map;
        }

        public MapTextWriter(CharacterMap map, bool isWordWrapping)
        {
            this.map = map;
            this.isWordWrapping = isWordWrapping;
        }

        public MapTextWriter(CharacterMap map, bool isWordWrapping, int wordWrapXPosition)
        {
            this.map = map;
            this.isWordWrapping = isWordWrapping;
            this.wordWrapXPosition = wordWrapXPosition;
        }

        public MapTextWriter(CharacterMap map, bool isWordWrapping, Vector2 initialPrintPosition)
        {
            this.map = map;
            this.isWordWrapping = isWordWrapping;
            this.initialPrintPosition = initialPrintPosition;
        }

        public MapTextWriter(CharacterMap map, bool isWordWrapping, Vector2 initialPrintPosition, int wordWrapXPosition)
        {
            this.map = map;
            this.isWordWrapping = isWordWrapping;
            this.initialPrintPosition = initialPrintPosition;
            this.wordWrapXPosition = wordWrapXPosition;
        }

        #endregion

        #region Behaviors

        public override void OnLink(IDataLinker linker)
        {
            characters = linker.LinkObjectList("characters", characters);
            cursorPosition = linker.LinkInt("cursorPosition", cursorPosition);
            isWordWrapping = linker.LinkBool("isWordWrapping", isWordWrapping);
        }

        #endregion

        // Overrides currentColor, but does not change it going forward.
        public void Write(char character, string color)
        {
            characters.Add(new Character(character, color));
            PrintCharacters();
        }

        // Writes using currentColor
        public void Write(char character)
        {
            Write(character, currentColor);
        }

        public void SetColor(string color)
        {
            currentColor = color;
        }

        void PrintCharacters()
        {
            map.SetPrintPosition(Vector2.Zero);
            for(int i = 0; i < characters.Count; i++)
            {
                if (isWordWrapping && characters[i].character != ' ' && CheckNextWordWraps(i))
                {
                    // clear until end and skip line.
                    while (map.CheckWithinBounds(map.printPosition)) 
                    {
                        PrintCharacter(new Character(' '));
                    }

                    map.SetPrintPosition(new Vector2(0, map.printPosition.y + 1));
                }

                PrintCharacter(characters[i]);
            }
        }

        // Write a single character and move the map's print position 1 to the right
        void PrintCharacter(Character character)
        {
            map.Print(character);
            map.SetPrintPosition(map.printPosition + new Vector2(1, 0));
        }

        bool CheckNextWordWraps(int peekIndex)
        {
            Vector2 peekPosition = map.printPosition;

            int wordLength = 0;
            while(characters.Count > peekIndex && characters[peekIndex].character != ' ')
            {
                if(peekPosition.x + wordLength > map.transform.rect.size.x - 1)
                {
                    return true;
                }

                wordLength++;
                peekIndex++;
            }

            return false;
        }
    }
}
