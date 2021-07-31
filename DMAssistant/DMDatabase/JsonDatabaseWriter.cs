using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMDatabase;
using System.Text.Json;

namespace DMDatabase
{
    class JsonDatabaseWriter : IDatabaseLinker
    {
        Utf8JsonWriter writer;
        IDatabaseLinkable linkable;

        public JsonDatabaseWriter(Utf8JsonWriter writer, IDatabaseLinkable linkable)
        {
            this.writer = writer;
            this.linkable = linkable;
        }

        public void SerializeElement()
        {
            linkable.OnLink(this);
        }

        public bool LinkBool(string key, bool value)
        {
            writer.WriteBoolean(key, value);
            return value;
        }

        public double LinkDouble(string key, double value)
        {
            writer.WriteNumber(key, value);
            return value;
        }

        public float LinkFloat(string key, float value)
        {
            writer.WriteNumber(key, value);
            return value;
        }

        public int LinkInt(string key, int value)
        {
            writer.WriteNumber(key, value);
            return value;
        }

        public string LinkString(string key, string value)
        {
            writer.WriteString(key, value);
            return value;
        }

        public T LinkObject<T>(string key, T value) where T : IDatabaseLinkable, new()
        {
            writer.WriteStartObject(key);

            JsonDatabaseWriter databaseWriter = new JsonDatabaseWriter(writer, value);
            databaseWriter.SerializeElement();

            writer.WriteEndObject();

            return value;
        }

        public List<T> LinkObjectList<T>(string key, List<T> value) where T : IDatabaseLinkable, new()
        {
            writer.WriteStartArray(key);

            foreach(T obj in value)
            {
                // redundant code. can fix with a touch of time. don't really care.
                writer.WriteStartObject();

                JsonDatabaseWriter databaseWriter = new JsonDatabaseWriter(writer, obj);
                databaseWriter.SerializeElement();

                writer.WriteEndObject();
            }

            writer.WriteEndArray();

            return value;
        }

        public List<string> LinkStringList(string key, List<string> value)
        {
            writer.WriteStartArray(key);

            foreach (string i in value)
            {
                writer.WriteStringValue(i);
            }

            writer.WriteEndArray();

            return value;
        }

        public List<bool> LinkBoolList(string key, List<bool> value)
        {
            writer.WriteStartArray(key);

            foreach (bool i in value)
            {
                writer.WriteBooleanValue(i);
            }

            writer.WriteEndArray();

            return value;
        }

        public List<int> LinkIntList(string key, List<int> value)
        {
            writer.WriteStartArray(key);

            foreach (int i in value)
            {
                writer.WriteNumberValue(i);
            }

            writer.WriteEndArray();

            return value;
        }

        public List<double> LinkDoubleList(string key, List<double> value)
        {
            writer.WriteStartArray(key);

            foreach (double i in value)
            {
                writer.WriteNumberValue(i);
            }

            writer.WriteEndArray();

            return value;
        }

        public List<float> LinkFloatList(string key, List<float> value)
        {
            writer.WriteStartArray(key);

            foreach (float i in value)
            {
                writer.WriteNumberValue(i);
            }

            writer.WriteEndArray();

            return value;
        }
    }
}
