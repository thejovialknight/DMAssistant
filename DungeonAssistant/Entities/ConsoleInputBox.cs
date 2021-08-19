using DMEngine;
using DMEngine.CharacterMapRenderer;
using DMEngine.Input;
using DMEngine.CharacterTransform;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAssistant.Entities
{
    class ConsoleInputBox : Entity
    {
        RectTransform transform;
        CharacterMap map;
        MapTextWriter mapTextWriter;
        InputAcceptor inputAcceptor;
        TextWriterInput textWriterInput;

        public override void OnInitialize()
        {
            transform = AddComponent(new RectTransform());
            mapTextWriter = AddComponent(new MapTextWriter());
        }
    }
}
