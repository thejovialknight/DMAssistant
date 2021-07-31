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

        public void OnDeserialize(IDatabaseReader reader)
        {
            name = reader.DeserializeString("Name", name);
            amount = reader.DeserializeInt("Amount", amount);
        }

        public void OnSerialize(IDatabaseWriter writer)
        {
            writer.SerializeString("Name", name);
            writer.SerializeInt("Amount", amount);
        }
    }
}
