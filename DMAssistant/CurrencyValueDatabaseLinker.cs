using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMDatabase;

namespace DMAssistant
{

    class CurrencyValueDatabaseLinker : DatabaseLinker
    {
        CurrencyValue data;

        public CurrencyValueDatabaseLinker(CurrencyValue data)
        {
            this.data = data;
        }
        public override void OnDeserializeField(IDatabaseReader reader)
        {
            base.OnDeserializeField(reader);

            data.currencies = reader.DeserializeListLinkable("Currency", "Currencies", data.currencies);
        }

        public override void OnSerialize(IDatabaseWriter writer)
        {
            base.OnSerialize(writer);

            writer.SerializeListLinkable("Currency", "Currencies", data.currencies);
        }
    }
}
