using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;

namespace DMDatabase
{
    // This class is a JSON implementation of IDatabase
    class JsonDatabase : IDatabase
    {
        public void DeserializeFromFile(string fName, IDatabaseLinkable data)
        {
            var options = new JsonReaderOptions
            {
                AllowTrailingCommas = true,
                CommentHandling = JsonCommentHandling.Skip
            };

            Fi reader = new Utf8JsonReader(jsonUtf8Bytes, options);

            while (reader.Read())
            {
                Console.Write(reader.TokenType);

                switch (reader.TokenType)
                {
                    case JsonTokenType.PropertyName:
                    case JsonTokenType.String:
                        {
                            string text = reader.GetString();
                            Console.Write(" ");
                            Console.Write(text);
                            break;
                        }

                    case JsonTokenType.Number:
                        {
                            int intValue = reader.GetInt32();
                            Console.Write(" ");
                            Console.Write(intValue);
                            break;
                        }

                        // Other token types elided for brevity
                }
                Console.WriteLine();
            }
        }

        public void SerializeToFile(string fName, IDatabaseLinkable data)
        {
            if (!File.Exists(fName))
            {
                // NO FILE FOUND!
                return;
            }

            JsonWriterOptions options = new JsonWriterOptions
            {
                Indented = true
            };

            FileStream stream = new FileStream(fName, FileMode.Open);
            Utf8JsonWriter writer = new Utf8JsonWriter(stream, options);

            JsonDatabaseReader reader = new JsonDatabaseReader(writer);
            data = reader.SerializeLinkable("Root", data);
            writer.Flush();
        }
    }
}
