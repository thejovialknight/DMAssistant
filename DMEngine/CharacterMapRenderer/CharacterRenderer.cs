using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMEngine.Database;
using DMEngine.Transform;

namespace DMEngine.CharacterMapRenderer
{
    public class CharacterRenderer : EntityGraph
    {
        List<CharacterMap> maps = new List<CharacterMap>();

        public void UpdateMap(CharacterMap map)
        {
            // If the map has moved
            if (map.isSizeOrPositionDifferent)
            {
                RenderMap(map);
                return;
            }

            // Print only character differences
            foreach (CharacterDifference difference in map.differences)
            {
                Print(difference.newCharacter, difference.position);
            }
        }

        // Render object and all children regardless of differences.
        public void RenderMap(CharacterMap map)
        {
            map.ClearDifferences();
            map.isSizeOrPositionDifferent = false;

            // Print every character in the map.
            for (int x = 0; x < map.coordinates.GetLength(0); x++)
            {
                for (int y = 0; y < map.coordinates[x].Length; y++)
                {
                    Vector2 position = new Vector2(x, y);
                    Print(map.coordinates[x][y], position);
                }
            }
        }

        public void Print(Character character, Vector2 position)
        {
            if(character == null)
            {
                character = new Character(' ', "White");
            }

            // Check if outside the bounds of the console buffer
            if (position.x < 0 || position.x > Console.BufferWidth
            || position.y < 0 || position.y > Console.BufferHeight)
            {
                return;
            }

            // Set position, color, and write to the console buffer
            Console.SetCursorPosition(position.x, position.y);
            Console.ForegroundColor = character.Color();
            Console.Write(character.character);
        }

        public override void OnInitialize()
        {
            game.onEntityCreated += TryRegisterMap;
            game.onEntityDestroyed += TryRemoveMap;
        }

        public override void OnPostInitialize()
        {
            foreach(CharacterMap map in maps)
            {
                //RenderMap(map);
            }
        }

        public override void OnTick(double deltaTime)
        {
            foreach (CharacterMap map in maps)
            {
                if(map != null)
                {
                    UpdateMap(map);
                }
            }
        }

        public void TryRegisterMap(Entity entity, EntityGraph graph)
        {
            CharacterMap map = entity.Component<CharacterMap>();
            if(map != null)
            {
                maps.Add(map);
            }
        }

        public void TryRemoveMap(Entity entity, EntityGraph graph)
        {
            CharacterMap map = entity.Component<CharacterMap>();
            if (map != null && maps.Contains(map))
            {
                maps.Remove(map);
            }
        }
    }
}
