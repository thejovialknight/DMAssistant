using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMDatabase;

namespace DMAssistant
{
    class World : IDatabaseLinkable
    {
        public void OnDeserialize(IDatabaseReader reader)
        {
            throw new NotImplementedException();
        }

        public void OnSerialize(IDatabaseWriter writer)
        {
            throw new NotImplementedException();
        }
    }
}
