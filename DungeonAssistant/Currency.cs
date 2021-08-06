using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMEngine.Database;

namespace DMAssistant
{
    class Currency : IDataLinkable
    {
        public string name = "Currency Name Here";
        public int amount = 0;

        public void OnLink(IDataLinker linker)
        {
            name = linker.LinkString("Name", name);
            amount = linker.LinkInt("Amount", amount);
        }
    }
}
