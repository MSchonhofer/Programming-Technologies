using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;
using Data.API;

namespace Presentation.Model.API
{
    public interface IReturnBookModelData
    {
        IService service { get; }
        IReturnBookModelView CreateReturn(IBook book, Data.API.IReader reader);
    }
}
