﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public abstract class IFill
    {
        public abstract void Fill(IDataRepository dataRepository);
    }
}
