using DMEngine.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMEngine.Input
{
    public class InputAcceptor : Component
    {
        public delegate void OnKeyEvent(ConsoleKeyInfo key);
        public event OnKeyEvent onKey;

        public void RaiseOnKey(ConsoleKeyInfo key)
        {
            onKey?.Invoke(key);
        }

        public override void OnPostInitialize()
        {

        }
    }
}
