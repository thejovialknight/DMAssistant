﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DMDatabase;

namespace DMAssistant
{
    class Item : IDatabaseLinkable
    {
        public string name;
        public CurrencyValue value;

        public IDatabaseLinker GetDatabaseLinker()
        {
            throw new NotImplementedException();
        }
    }
}
