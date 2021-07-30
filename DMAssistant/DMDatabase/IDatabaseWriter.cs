using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMDatabase
{
    // The task of this class is to be passed into IDatabaseLinkers and run through each field
    // in a single "object" in the database, abstracting the specificities of something like
    // JSON or XML so the linker can remain uncouple from implementation.
    // Therefore the implementations of the interface would be called something like JsonDatabaseReader.
    interface IDatabaseWriter
    {
        /* These two methods are called by the IDatabaseLinker within OnSerialize(). May or may not be needed. Doesn't really seem like it.

        // Returns whether the currently searching for result has been found.
        bool CheckResult();
        // Resets the result to false to check a new field.
        void ResetResult();
        */

        bool NextField();

        // These methods are called by the IDatabaseLinker to deserialize specific fields within OnSerializeField()

        // These methods return the previously held value (cur) if the field doesn't match, and set
        // the result of a CheckResult() call to true if matched.
        // Will want methods for lists as well as serialization perhaps? Perhaps a different
        // interface entirely for that.
        T SerializeField<T>(string key, T value);

        // for linkable data types as fields
        T SerializeLinkable<T>(string key, T linkable) where T : IDatabaseLinkable, new();

        // These are for serializing lists.
        // Runs through each item in the list and performs a call of the non list version for each one (?)
        List<T> SerializeListField<T>(string key, List<T> list);

        List<T> SerializeListLinkable<T>(string key, string listKey, List<T> linkables) where T : IDatabaseLinkable, new();
    }
}
