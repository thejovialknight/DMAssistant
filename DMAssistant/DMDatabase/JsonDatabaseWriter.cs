using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMDatabase;
using System.Text.Json;

namespace DMDatabase
{
    class JsonDatabaseWriter : IDatabaseWriter
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
            linkable.OnSerialize(this);
        }

        public void SerializeBool(string key, bool value)
        {
            writer.WriteBoolean(key, value);
        }

        public void SerializeDouble(string key, double value)
        {
            writer.WriteNumber(key, value);
        }

        public void SerializeFloat(string key, float value)
        {
            writer.WriteNumber(key, value);
        }

        public void SerializeInt(string key, int value)
        {
            writer.WriteNumber(key, value);
        }

        public void SerializeString(string key, string value)
        {
            writer.WriteString(key, value);
        }

        public void SerializeLinkable<T>(string key, T value) where T : IDatabaseLinkable, new()
        {
            writer.WriteStartObject(key);

            JsonDatabaseWriter databaseWriter = new JsonDatabaseWriter(writer, value);
            databaseWriter.SerializeElement();

            writer.WriteEndObject();
        }

        public void SerializeListLinkable<T>(string key, List<T> list) where T : IDatabaseLinkable, new()
        {
            writer.WriteStartArray(key);

            foreach(T obj in list)
            {
                // redundant code. can fix with a touch of time. don't really care.
                writer.WriteStartObject();

                JsonDatabaseWriter databaseWriter = new JsonDatabaseWriter(writer, obj);
                databaseWriter.SerializeElement();

                writer.WriteEndObject();
            }

            writer.WriteEndArray();
        }
    }
}
