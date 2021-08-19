using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMEngine.Database;
using DMEngine.CharacterTransform;

namespace DMEngine.CharacterMapRenderer
{
    // Interface for the actual character map.
    public class CharacterMap : Component
    {
        public RectTransform transform;
        public List<MapCharacter> mapCharacters = new List<MapCharacter>();
        public Vector2 printPosition = new Vector2();
        public bool isSizeOrPositionDifferent = true;

        Vector2 previousGlobalPosition;

        public CharacterMap()
        {

        }

        public CharacterMap(RectTransform transform)
        {
            this.transform = transform;
        }

        public void ClearDifferences()
        {
            mapCharacters.Clear();
        }

        public void SetPrintPosition(Vector2 pos)
        {
            printPosition = pos;
        }

        public void Print(Character character, Vector2 position)
        {
            if(CheckWithinBounds(position))
            {
                foreach (MapCharacter mapCharacter in mapCharacters)
                {
                    if(mapCharacter.position == position)
                    {
                        mapCharacter.oldCharacter = mapCharacter.newCharacter;
                        mapCharacter.newCharacter = character;
                        return;
                    }
                }

                mapCharacters.Add(new MapCharacter(null, character, position));
            }
        }

        public bool CheckWithinBounds(Vector2 position)
        {
            return (transform.Size().x > position.x && transform.Size().y > position.y && position.x >= 0 && position.y >= 0);
        }

        public void Print(Character character)
        {
            Print(character, printPosition);
        }

        public override void OnInitialize()
        {
            UpdatePreviousPosition();
        }

        public override void OnLink(IDataLinker linker)
        {
            transform = linker.LinkObject("transform", transform);
            printPosition = linker.LinkObject("printPosition", printPosition);
            // mapCharacters = linker.LinkObject("mapCharacters", mapCharacters);
        }

        public override void OnTick(double deltaTime)
        {
            if(previousGlobalPosition != transform.GlobalPosition())
            {
                isSizeOrPositionDifferent = true;
            }

            UpdatePreviousPosition();
        }

        void UpdatePreviousPosition()
        {
            previousGlobalPosition = transform.GlobalPosition();
        }
    }
}
