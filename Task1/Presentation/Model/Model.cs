using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Logic.API;

namespace Presentation.Model
{
    public class Model : IModel
    {
        private ILibrary library;

        public Model(ILibrary library = default(ILibrary))
        {
            if (library == null)
            {
                this.library = ILibrary.CreateLogic();
            }
            else
            {
                this.library = library;
            }
        }
        public ILibrary Library { get { return library; } }

    }
}
