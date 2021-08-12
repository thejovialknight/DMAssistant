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
    class 
        TextWriterInput : Component
    {
        InputAcceptor inputAcceptor;

        public void OnKey(ConsoleKeyInfo key)
        {
            Console.WriteLine("Funky keys activated!");
        }

        public override void OnInitialize()
        {
            inputAcceptor = entity.Component<InputAcceptor>();
            inputAcceptor.onKey += OnKey;
        }
    }
}
