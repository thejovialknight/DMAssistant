using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMDatabase
{
    // The interface for the go-between from the database to a piece of data.
    // There is a different interface for each type of data.
    // The linker has no knowledge of specific implementations like JSON or XML
    interface IDatabaseLinker
    {
        // Runs through each field, calls OnSerializeField to
        // No OnSerializeField because the linker just has to call each single line in turn to the reader,
        // no issue.
        void Serialize(IDatabaseWriter writer);

        void Deserialize(IDatabaseReader reader);
        void OnSerialize(IDatabaseWriter writer);
        // 
        void OnDeserializeField(IDatabaseReader reader);
    }
}
