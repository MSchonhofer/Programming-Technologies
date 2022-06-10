using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.API
{
    public interface IReturnBookModelView
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public IReader Reader { get; set; }
    }
}
