using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMEngine.Database;

namespace DMAssistant
{
    // This data class represents a monetary value as a list of currencies with names and amounts.
    class CurrencyValue : IDataLinkable
    {
        // copmmented to make serialization easier
        //public List<Currency> currencies = new List<Currency>();
        public Currency currency = new Currency();

        public void OnLink(IDataLinker linker)
        {
            currency = linker.LinkObject("Currency", currency);
        }
    }
}
