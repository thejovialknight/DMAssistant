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
        // copmmented to make serialization easier
        //public List<Currency> currencies = new List<Currency>();
        public Currency currency = new Currency();

        public void OnDeserialize(IDatabaseReader reader)
        {
            currency = reader.DeserializeLinkable("Currency", currency);
        }

        public void OnSerialize(IDatabaseWriter writer)
        {
            writer.SerializeLinkable("Currency", currency);
        }
    }
}
