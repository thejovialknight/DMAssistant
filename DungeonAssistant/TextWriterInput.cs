using DMEngine;
using DMEngine.Database;
using DMEngine.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DungeonAssistant
{
    class TextWriterInput : Component
    {
        InputAcceptor inputAcceptor;
        MapTextWriter mapTextWriter;

        public TextWriterInput()
        {

        }

        public TextWriterInput(InputAcceptor inputAcceptor, MapTextWriter mapTextWriter)
        {
            this.inputAcceptor = inputAcceptor;
            this.mapTextWriter = mapTextWriter;
        }

        public void OnKey(ConsoleKeyInfo key)
        {
            mapTextWriter.Write(key.KeyChar);
        }

        public override void OnInitialize()
        {
            inputAcceptor.onKey += OnKey;
        }
    }
}
