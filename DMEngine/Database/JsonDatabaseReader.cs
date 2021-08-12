using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace DMEngine.Database
{
    // Using document, different reader for each element
    public class JsonDatabaseReader : IDataLinker
    {
        JsonElement element;
        IDataLinkable linkable;

        public JsonDatabaseReader(JsonElement element, IDataLinkable linkable)
        {
            this.element = element;
            this.linkable = linkable;
        }

        public void DeserializeElement()
        {
            linkable.Link(this);
        }

        public bool LinkBool(string key, bool def)
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

        public double LinkDouble(string key, double def)
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

        public float LinkFloat(string key, float def)
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

        public int LinkInt(string key, int def)
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

        public string LinkString(string key, string def)
        {
            JsonElement field;
            if (element.TryGetProperty(key, out field))
            {
                if (field.ValueKind == JsonValueKind.String)
                    return field.GetString();
            }

            return def;
        }

        public T LinkObject<T>(string key, T current) where T : IDataLinkable, new()
        {
            JsonElement newElement;
            if(element.TryGetProperty(key, out newElement))
            {
                JsonDatabaseReader reader = new JsonDatabaseReader(newElement, current);
                reader.DeserializeElement();
            }

            return current;
        }

        public List<T> LinkObjectList<T>(string key, List<T> value) where T : IDataLinkable, new()
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

            return value;
        }

        // PRIMITIVE LIST GETTERS.
        // TODO: USE TryGetString() in an if statement before adding it to the list.
        // Don't want to be getting bad data!!

        public List<string> LinkStringList(string key, List<string> value)
        {
            JsonElement listElement;
            if (element.TryGetProperty(key, out listElement))
            {
                if (listElement.ValueKind == JsonValueKind.Array)
                {
                    List<string> newList = new List<string>();
                    JsonElement.ArrayEnumerator enumerator = listElement.EnumerateArray();
                    foreach (JsonElement arrayElement in enumerator)
                    {
                        newList.Add(arrayElement.GetString());
                    }

                    return newList;
                }
            }

            return value;
        }

        public List<bool> LinkBoolList(string key, List<bool> value)
        {
            JsonElement listElement;
            if (element.TryGetProperty(key, out listElement))
            {
                if (listElement.ValueKind == JsonValueKind.Array)
                {
                    List<bool> newList = new List<bool>();
                    JsonElement.ArrayEnumerator enumerator = listElement.EnumerateArray();
                    foreach (JsonElement arrayElement in enumerator)
                    {
                        newList.Add(arrayElement.GetBoolean());
                    }

                    return newList;
                }
            }

            return value;
        }

        public List<int> LinkIntList(string key, List<int> value)
        {
            JsonElement listElement;
            if (element.TryGetProperty(key, out listElement))
            {
                if (listElement.ValueKind == JsonValueKind.Array)
                {
                    List<int> newList = new List<int>();
                    JsonElement.ArrayEnumerator enumerator = listElement.EnumerateArray();
                    foreach (JsonElement arrayElement in enumerator)
                    {
                        newList.Add(arrayElement.GetInt32());
                    }

                    return newList;
                }
            }

            return value;
        }

        public List<double> LinkDoubleList(string key, List<double> value)
        {
            JsonElement listElement;
            if (element.TryGetProperty(key, out listElement))
            {
                if (listElement.ValueKind == JsonValueKind.Array)
                {
                    List<double> newList = new List<double>();
                    JsonElement.ArrayEnumerator enumerator = listElement.EnumerateArray();
                    foreach (JsonElement arrayElement in enumerator)
                    {
                        newList.Add(arrayElement.GetDouble());
                    }

                    return newList;
                }
            }

            return value;
        }

        public List<float> LinkFloatList(string key, List<float> value)
        {
            JsonElement listElement;
            if (element.TryGetProperty(key, out listElement))
            {
                if (listElement.ValueKind == JsonValueKind.Array)
                {
                    List<float> newList = new List<float>();
                    JsonElement.ArrayEnumerator enumerator = listElement.EnumerateArray();
                    foreach (JsonElement arrayElement in enumerator)
                    {
                        newList.Add(arrayElement.GetSingle());
                    }

                    return newList;
                }
            }

            return value;
        }
    }
}
