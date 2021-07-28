using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMAssistant.DMDatabase
{
    // The task of this class is to be passed into IDatabaseLinkers and run through each field
    // in a single "object" in the database, abstracting the specificities of something like
    // JSON or XML so the linker can remain uncouple from implementation.
    // Therefore the implementations of the interface would be called something like JsonDatabaseObject.
    interface IDatabaseObject
    {
        // These two methods are called by the IDatabaseLinker within OnSerialize()

        // Returns whether the currently searching for result has been found.
        bool CheckResult();
        // Resets the result to false to check a new field.
        void ResetResult();

        // These methods are called by the IDatabaseLinker to deserialize specific fields within OnSerializeField()

        // These methods return the previously held value (cur) if the field doesn't match, and set
        // the result of a CheckResult() call to true if matched.
        // Will want methods for lists as well as serialization perhaps? Perhaps a different
        // interface entirely for that.
        int DeserializeInt(string key, int cur);
        string DeserializeString(string key, string cur);
        bool DeserializeBool(string key, bool cur);

    }
}
