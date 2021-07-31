using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMDatabase;

namespace DMAssistant
{
    class Program
    {
        static void Main(string[] args)
        {
            JsonDatabase database = new JsonDatabase();
            Item item = new Item();

            /* creating the configured values */
            //item = ConfigureItem();
            //Serialize(item, database);

            /* creating the configured values */
            Deserialize(item, database);

            PrintItem(item);

            Console.ReadKey();
        }

        public static void Serialize(IDatabaseLinkable linkable, IDatabase db)
        {
            db.SerializeToFile("ItemData.json", linkable);
        }

        public static void Deserialize(IDatabaseLinkable linkable, IDatabase db)
        {
            db.DeserializeFromFile("ItemData.json", linkable);
        }

        public static Item ConfigureItem()
        {
            Item item = new Item();
            item.name = "Sword of Akatosh";
            item.values.Add(new Currency { name = "Parsels", amount = 21 } );
            item.values.Add(new Currency { name = "Dracions", amount = 3 });
            return item;
        }

        public static void PrintItem(Item item)
        {
            Console.WriteLine("Name: " + item.name);

            foreach(Currency value in item.values)
                Console.WriteLine("Value: " + value.amount + " " + value.name);
        }
    }
}
