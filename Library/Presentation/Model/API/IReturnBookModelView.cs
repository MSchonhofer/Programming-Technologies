using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface IReturnBookModelView
    {
        public IBook book { get; set; }
        public IReader Reader { get; set; }
    }
}
