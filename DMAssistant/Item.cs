using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMDatabase;

namespace DMAssistant
{
    class Item : IDatabaseLinkable
    {
        public string name = "Name not set";
        public List<Currency> values = new List<Currency>();

        public void OnDeserialize(IDatabaseReader reader)
        {
            name = reader.DeserializeString("Name", name);
            values = reader.DeserializeListLinkable("Values", values);
        }

        public void OnSerialize(IDatabaseWriter writer)
        {
            writer.SerializeString("Name", name);
            writer.SerializeListLinkable("Values", values);
        }
    }
}
