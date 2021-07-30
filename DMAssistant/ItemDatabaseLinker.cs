using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMDatabase;

namespace DMAssistant
{
    // The item implementation for IDatabaseLinker.
    class ItemDatabaseLinker : DatabaseLinker
    {
        public Item data;

        public ItemDatabaseLinker(Item data)
        {
            this.data = data;
        }

        public override void OnDeserializeField(IDatabaseReader reader)
        {
            base.OnDeserializeField(reader);

            data.name = reader.DeserializeField("Name", data.name);
            data.value = reader.DeserializeLinkable("Cost", data.value);
        }

        public override void OnSerialize(IDatabaseWriter writer)
        {
            base.OnSerialize(writer);

            writer.SerializeField("Name", data.name);
            writer.SerializeLinkable("Cost", data.value);
        }
    }
}
