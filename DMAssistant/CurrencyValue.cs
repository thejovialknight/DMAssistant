using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMDatabase;

namespace DMAssistant
{
    // This data class represents a monetary value as a list of currencies with names and amounts.
    class CurrencyValue : IDatabaseLinkable
    {
        public List<Currency> currencies = new List<Currency>();

        public IDatabaseLinker GetDatabaseLinker()
        {
            return new CurrencyValueDatabaseLinker(this);
        }
    }
}
