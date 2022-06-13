﻿using Presentation.Model.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.Implementation
{
    internal class RentBookModelView : IRentBookModelView
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public IReader Reader { get; set; }

        public RentBookModelView(string author, string title, IReader reader)
        {
            Author = author;
            Title = title;
            Reader = reader;
        }
    }
}