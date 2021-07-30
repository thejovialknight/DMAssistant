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
        public string name;
        public int amount;

        public IDatabaseLinker GetDatabaseLinker()
        {
            return new CurrencyDatabaseLinker(this);
        }
    }
}
