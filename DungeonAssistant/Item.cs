using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMEngine.Database;

namespace DMAssistant
{
    class Item : IDataLinkable
    {
        public string name = "Name not set";
        public List<Currency> values = new List<Currency>();

        public void OnLink(IDataLinker linker)
        {
            name = linker.LinkString("Name", name);
            values = linker.LinkObjectList("Values", values);
        }
    }
}
