using Presentation.Model.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;

namespace Presentation.Model.Implementation
{
    internal class RentBookModelData : IRentBookModelData
    {
        public IService service { get; }
        public RentBookModelData(IService service)
        {
            this.service = service;
        }

        public IRentBookModelView CreateRent(string author, string title, IReader reader)
        {
            return new RentBookModelView(author, title, reader);
        }
    }
}
