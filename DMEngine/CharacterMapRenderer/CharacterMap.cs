using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMEngine.Database;
using DMEngine.Transform;

namespace DMEngine.CharacterMapRenderer
{
    // Interface for the actual character map.
    public class CharacterMap : Component
    {
        public RectTransform transform;
        public Character[][] coordinates;
        public List<CharacterDifference> differences = new List<CharacterDifference>();
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
            differences.Clear();
        }

        public void Print(Character character, Vector2 position)
        {
            //if(coordinates[position.x][position.y].character != character.character)
            //{
                coordinates[position.x][position.y] = character;
                differences.Add(new CharacterDifference(character, position));
            //}
        }

        public override void OnInitialize()
        {
            transform = entity.Component<RectTransform>();

            if(transform != null)
            {
                coordinates = new Character[transform.rect.size.x][];
                for(int x = 0; x < coordinates.GetLength(0); x++)
                {
                    coordinates[x] = new Character[transform.rect.size.y];
                }
            }

            UpdatePreviousPosition();
        }

        public override void OnLink(IDataLinker linker)
        {
            transform = linker.LinkObject("transform", transform);

            List<CharacterColumn> columns = new List<CharacterColumn>();
            for(int x = 0; x < coordinates.GetLength(0); x++)
            {
                CharacterColumn column = new CharacterColumn();
                columns.Add(column);
                column.characters = coordinates[x].ToList();
            }

            columns = linker.LinkObjectList("columns", columns);
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
