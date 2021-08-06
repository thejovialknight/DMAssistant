using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace DMEngine.Database
{
    // This class is a JSON implementation of IDatabase
    public class JsonDatabase : IDatabase
    {
        public void SerializeToFile(string fName, IDataLinkable data)
        {
            // Declare the JsonWriterOptions
            var options = new JsonWriterOptions
            {
                Indented = true
            };

            // Write to memory stream
            FileStream stream = new FileStream(fName, FileMode.Create);
            Utf8JsonWriter writer = new Utf8JsonWriter(stream, options);

            writer.WriteStartObject();
            JsonDatabaseWriter dbWriter = new JsonDatabaseWriter(writer, data);
            dbWriter.SerializeElement();
            writer.WriteEndObject();

            writer.Flush();

            // Copy stream to file. Might want to just encode to string and write that?
            // FileStream fileStream = new FileStream(fName, FileMode.Create);
            // stream.CopyTo(fileStream);
            // fileStream.Flush();

            // NOT REALLY NEEDED. Encode to string and write to console.
            // string json = Encoding.UTF8.GetString(stream.ToArray());
            // Console.WriteLine(json);
        }

        public void DeserializeFromFile(string fName, IDataLinkable data)
        {
            if (!File.Exists(fName))
            {
                // NO FILE FOUND!
                return;
            }

            using (JsonDocument document = JsonDocument.Parse(File.ReadAllText(fName)))
            {
                JsonElement root = document.RootElement;
                JsonDatabaseReader dbReader = new JsonDatabaseReader(root, data);
                dbReader.DeserializeElement();
            }
        }
    }
}
