using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMAssistant.DMDatabase
{
    // The interface for the go-between from the database to a piece of data.
    // There is a different interface for each type of data.
    // The linker has no knowledge of specific implementations like JSON or XML
    interface IDatabaseLinker
    {
        // Runs through each field, calls OnSerializeField to
        void OnSerialize(IDatabaseObject obj);
        // 
        bool OnSerializeField(IDatabaseObject obj);
    }
}
