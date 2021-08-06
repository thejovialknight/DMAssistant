using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DMEngine.CharacterMapRenderer
{
    // Interface for an object which has a character map.
    public interface ICharacterMappable
    {
        CharacterMap GetMap();
        ICharacterMappable[] GetChildren();
    }
}
