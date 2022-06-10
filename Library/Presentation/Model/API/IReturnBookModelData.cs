using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;

namespace Presentation.Model.API
{
    public interface IReturnBookModelData
    {
        IService service { get; }
        IReturnBookModelView CreateReturn(string author, string title, IReader reader);
    }
}
