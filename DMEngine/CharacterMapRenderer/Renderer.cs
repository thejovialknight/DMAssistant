using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMEngine.Transform;

namespace DMEngine.CharacterMapRenderer
{
    public class Renderer
    {
        public ICharacterMappable mappable;
        public ICharacterMappable parent;

        public Renderer(ICharacterMappable root, ICharacterMappable parent)
        {
            this.mappable = root;
            this.parent = parent;
        }

        // TODO: THESE METHODS CAN PROBABLY BE REFACTORED FOR LESS CODE REUSE, YEAH?
        // Only update changed characters
        public void Update()
        {
            CharacterMap map = mappable.GetMap();
            if(map.isSizeOrPositionDifferent)
            {
                Render();
            }

            foreach (CharacterDifference difference in map.differences)
            {
                Print(difference.newCharacter, difference.position);
            }

            // Create new Renderer for each child and update entirely.
            foreach (ICharacterMappable child in mappable.GetChildren())
            {
                Renderer renderer = new Renderer(child, mappable);
                renderer.Update();
            }
        }

        // Render object and all children regardless of differences.
        public void Render()
        {
            CharacterMap map = mappable.GetMap();
            map.ClearDifferences();
            map.isSizeOrPositionDifferent = false;

            // Print every character in the map.
            for (int x = 0; x < map.map.GetLength(0); x++)
            {
                for (int y = 0; y < map.map.GetLength(1); y++)
                {
                    Vector2 position = new Vector2(x, y);
                    Print(map.map[x, y], position);
                }
            }

            // Create new Renderer for each child and render entirely.
            foreach (ICharacterMappable child in mappable.GetChildren())
            {
                Renderer renderer = new Renderer(child, mappable);
                renderer.Render();
            }
        }

        public void Print(Character character, Vector2 position)
        {
            // Get maps
            CharacterMap parentMap = parent.GetMap();
            CharacterMap map = mappable.GetMap();

            // Add offset
            position = position + parentMap.rect.position + map.rect.position;

            // Check if outside of bounds of parent rect
            if (position.x < parentMap.rect.position.x 
            || position.x > parentMap.rect.position.x + parentMap.rect.size.x
            || position.y < parentMap.rect.position.y
            || position.y > parentMap.rect.position.y + parentMap.rect.size.y)
            {
                return;
            }

            // Check if outside the bounds of the console buffer
            if (position.x < 0 || position.x > Console.BufferWidth
            || position.y < 0 || position.y > Console.BufferHeight)
            {
                return;
            }

            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = character.color;
            Console.Write(character.character);
        }
    }
}
