using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMDatabase
{
    // Interface for a class with fields to link through the IDatabaseLinker.
    // Only exists for retrieval of the IDatabaseLinker.
    interface IDatabaseLinkable
    {
        void OnSerialize(IDatabaseWriter writer);
        void OnDeserialize(IDatabaseReader reader);
    }
}
