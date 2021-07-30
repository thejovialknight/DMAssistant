using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using DMDatabase;

namespace DMAssistant
{
    // This class is responsible for taking data from the database and passing it in a readable format to the 
    
    // actually not totally sure if this is necessary either. templates probably shouldn't be a thing. rather, World should be a structure that contains templates.
    class Persistence
    {
        public IDatabase database;

        Templates templates = new Templates();

        public Persistence(IDatabase database)
        {
            this.database = database;
        }


    }
}
