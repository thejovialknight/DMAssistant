﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMDatabase;

namespace DMAssistant
{
    class World : IDatabaseLinkable
    {
        public IDatabaseLinker GetDatabaseLinker()
        {
            throw new NotImplementedException();
        }
    }
}
