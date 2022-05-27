using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.API;

namespace Presentation.Model
{
    public interface IModel
    {
        ILibrary Library
        {
            get;
        }
    }
}
