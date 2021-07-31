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
    interface IDatabaseReader
    {
        string DeserializeString(string key, string def);
        bool DeserializeBool(string key, bool def);
        int DeserializeInt(string key, int def);
        double DeserializeDouble(string key, double def);
        float DeserializeFloat(string key, float def);
        T DeserializeLinkable<T>(string key, T cur) where T : IDatabaseLinkable, new(); // generics to pass as type rather than instance? maybe?
        List<T> DeserializeListLinkable<T>(string key, List<T> list) where T : IDatabaseLinkable, new(); // generics to pass as type rather than instance? maybe?
    }
}
