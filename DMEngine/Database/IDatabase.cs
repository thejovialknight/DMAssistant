using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMEngine.Database
{
    // The central database which deserializes to and from the file and hosts the reader of data.
    // An interface so as to leave open the possibility of a different format than JSON.
    public interface IDatabase
    {
        void SerializeToFile(string fName, IDataLinkable data);
        void DeserializeFromFile(string fName, IDataLinkable data);
    }
}
