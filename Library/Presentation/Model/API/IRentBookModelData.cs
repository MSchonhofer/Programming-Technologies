using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;

namespace Presentation.Model.API
{
    public interface IRentBookModelData
    {
        IService service { get; }
        IRentBookModelView CreateRent(string author, string title, IReader reader);
    }
}
