using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMDatabase
{
    class DatabaseLinker : IDatabaseLinker
    {
        public void Deserialize(IDatabaseReader reader)
        {
            while(reader.NextField())
            {
                OnDeserializeField(reader);
            }
        }

        public void Serialize(IDatabaseWriter writer)
        {
            OnSerialize(writer);
        }

        public virtual void OnDeserializeField(IDatabaseReader reader)
        {
        }

        public virtual void OnSerialize(IDatabaseWriter writer)
        {
        }
    }
}
