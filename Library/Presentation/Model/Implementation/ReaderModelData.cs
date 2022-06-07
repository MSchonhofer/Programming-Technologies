using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Service.API;

namespace Presentation.Model.Implementation
{
    public class ReaderModelData : IReaderModelData
    {
        public IService service { get; }
        public ReaderModelData(IService service)
        {
            service = service;
        }
        public IEnumerable<IReader> Readers
        {
            get
            {
                IEnumerable<IReader> readers = service.GetAllReaders();
                return readers;
            }
        }
        public IReaderModelView CreateReader(string name, string surname, int id)
        {
            return new ReaderModelView(name, surname, id);
        }
    }
}
