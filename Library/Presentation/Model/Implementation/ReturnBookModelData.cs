using Presentation.Model.API;
using Service.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.Implementation
{
    internal class ReturnBookModelData : IReturnBookModelData
    {
        public IService service { get; }
        public ReturnBookModelData(IService service)
        {
            this.service = service;
        }

        public IReturnBookModelView CreateReturn(string author, string title, IReader reader)
        {
            return new ReturnBookModelView(author, title, reader);
        }
    }
}
