using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMEngine.Database;
using DMEngine.CharacterTransform;

namespace DMEngine.CharacterMapRenderer
{
    public class CharacterRenderer : EntityGraph
    {
        List<CharacterMap> maps = new List<CharacterMap>();

        public void UpdateMap(CharacterMap map)
        {
            // Print all the characters, but only if they are actually different
            foreach (MapCharacter mapCharacter in map.mapCharacters)
            {
                if(mapCharacter.oldCharacter != mapCharacter.newCharacter)
                {
                    Print(mapCharacter.newCharacter, mapCharacter.position + map.transform.rect.position);
                    mapCharacter.oldCharacter = mapCharacter.newCharacter;
                }
            }

            map.ClearDifferences();
        }

        public void Print(Character character, Vector2 position)
        {
            if(character == null)
            {
                return;
                //character = new Character(' ', "White");
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

            Console.SetCursorPosition(0, 21);
            Console.WriteLine("x: " + position.x + " / y: " + position.y + " printed character: " + character.character + "        ");
        }

        public override void OnInitialize()
        {
            game.onEntityCreated += TryRegisterMap;
            game.onEntityDestroyed += TryRemoveMap;
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
