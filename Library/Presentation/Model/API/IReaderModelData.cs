using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;

namespace Presentation.Model
{
    public interface IReaderModelData
    {
        IService service { get; }
        IEnumerable<IReader> Readers { get; }
        IReaderModelView CreateReader(string name, string surname, int id);
    }
}
