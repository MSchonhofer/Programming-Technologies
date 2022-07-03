﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.API
{
    public interface ICatalog
    {
        string Author { get; set; }
        string Title { get; set; }
        int CatalogID { get; set; }
    }
}
