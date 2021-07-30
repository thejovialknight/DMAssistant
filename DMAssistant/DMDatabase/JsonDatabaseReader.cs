using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace DMDatabase
{
    class JsonDatabaseReader : IDatabaseReader
    {
        public T Deserialize<T>(string key, T cur)
        {
            while (reader.NextField())
            {
                OnDeserializeField(reader);
            }
        }

        public T DeserializeField<T>(string key, T cur)
        {
            throw new NotImplementedException();
        }

        public T DeserializeLinkable<T>(string key, T cur) where T : IDatabaseLinkable, new()
        {
            throw new NotImplementedException();
        }

        public List<T> DeserializeListField<T>(string key, List<T> list)
        {
            throw new NotImplementedException();
        }

        // might not need these generics at all. kind of just need to parse through it don't we
        public List<T> DeserializeListLinkable<T>(string key, string listKey, List<T> list) where T : IDatabaseLinkable, new()
        {
            throw new NotImplementedException();
        }

        public bool NextField()
        {
            throw new NotImplementedException();
        }
    }
}
