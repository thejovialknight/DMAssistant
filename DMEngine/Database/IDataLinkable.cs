using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMEngine.Database
{
    // Interface for a class with fields to link through the IDataLinker.
    // Only exists for retrieval of the IDataLinker.
    public interface IDataLinkable
    {
        void OnLink(IDataLinker linker);
    }
}
