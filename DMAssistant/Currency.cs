using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMDatabase;

namespace DMAssistant
{
    class Currency : IDatabaseLinkable
    {
        public string name = "Currency Name Here";
        public int amount = 0;

        public void OnLink(IDatabaseLinker linker)
        {
            name = linker.LinkString("Name", name);
            amount = linker.LinkInt("Amount", amount);
        }
    }
}
