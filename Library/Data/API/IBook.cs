﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public interface IBook
    {
        ICatalog Catalog { get; set; }
        int BookID { get; set; }

    }
}
