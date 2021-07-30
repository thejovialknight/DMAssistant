using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMDatabase;

namespace DMAssistant
{
    class CurrencyDatabaseLinker : DatabaseLinker
    {
        Currency data;

        public CurrencyDatabaseLinker(Currency data)
        {
            this.data = data;
        }
        public override void OnDeserializeField(IDatabaseReader reader)
        {
            base.OnDeserializeField(reader);

            data.name = reader.DeserializeField("Name", data.name);
        }

        public override void OnSerialize(IDatabaseWriter writer)
        {
            base.OnSerialize(writer);

            data.name = writer.SerializeField("Name", data.name);
        }
    }
}