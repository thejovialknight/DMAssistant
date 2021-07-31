using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DMDatabase
{
    // Using document, different reader for each element
    class JsonDatabaseReader : IDatabaseReader
    {
        JsonElement element;
        IDatabaseLinkable linkable;

        public JsonDatabaseReader(JsonElement element, IDatabaseLinkable linkable)
        {
            this.element = element;
            this.linkable = linkable;
        }

        public void DeserializeElement()
        {
            linkable.OnDeserialize(this);
        }

        public bool DeserializeBool(string key, bool def)
        {
            JsonElement field;
            if(element.TryGetProperty(key, out field))
            {
                if (field.ValueKind == JsonValueKind.False)
                    return false;
                else if (field.ValueKind == JsonValueKind.True)
                    return true;
            }

            return def;
        }

        public double DeserializeDouble(string key, double def)
        {
            JsonElement field;
            if (element.TryGetProperty(key, out field))
            {
                double value;
                if (field.TryGetDouble(out value))
                    return value;
            }

            return def;
        }

        public float DeserializeFloat(string key, float def)
        {
            JsonElement field;
            if (element.TryGetProperty(key, out field))
            {
                float value;
                if (field.TryGetSingle(out value))
                    return value;
            }

            return def;
        }

        public int DeserializeInt(string key, int def)
        {
            JsonElement field;
            if (element.TryGetProperty(key, out field))
            {
                int value;
                if (field.TryGetInt32(out value))
                    return value;
            }

            return def;
        }

        public string DeserializeString(string key, string def)
        {
            JsonElement field;
            if (element.TryGetProperty(key, out field))
            {
                if (field.ValueKind == JsonValueKind.String)
                    return field.GetString();
            }

            return def;
        }

        public T DeserializeLinkable<T>(string key, T current) where T : IDatabaseLinkable, new()
        {
            JsonElement newElement;
            if(element.TryGetProperty(key, out newElement))
            {
                JsonDatabaseReader reader = new JsonDatabaseReader(newElement, current);
                reader.DeserializeElement();
            }

            return current;
        }

        public List<T> DeserializeListLinkable<T>(string key, List<T> list) where T : IDatabaseLinkable, new()
        {
            JsonElement listElement;
            if(element.TryGetProperty(key, out listElement))
            {
                if(listElement.ValueKind == JsonValueKind.Array)
                {
                    List<T> newList = new List<T>();
                    JsonElement.ArrayEnumerator enumerator = listElement.EnumerateArray();
                    foreach(JsonElement arrayElement in enumerator)
                    {
                        T newObject = new T();
                        newList.Add(newObject);

                        JsonDatabaseReader reader = new JsonDatabaseReader(arrayElement, newObject);
                        reader.DeserializeElement();
                    }

                    return newList;
                }
            }

            return list;
        }
    }
}
