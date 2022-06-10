using Presentation.Model.API;
using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.Implementation
{
    internal class ReturnBookModelView : IReturnBookModelView
    {
        public IBook book { get; set; }
        public IReader Reader { get; set; }

        public ReturnBookModelView(IBook book, IReader reader)
        {
            this.book = book;
            Reader = reader;
        }
    }
}
