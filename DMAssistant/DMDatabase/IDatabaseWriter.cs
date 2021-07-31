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
        void SerializeString(string key, string value);
        void SerializeBool(string key, bool value);
        void SerializeInt(string key, int value);
        void SerializeDouble(string key, double value);
        void SerializeFloat(string key, float value);
        void SerializeLinkable<T>(string key, T value) where T : IDatabaseLinkable, new(); // generics to pass as type rather than instance? maybe?
        void SerializeListLinkable<T>(string key, List<T> list) where T : IDatabaseLinkable, new();
    }
}
