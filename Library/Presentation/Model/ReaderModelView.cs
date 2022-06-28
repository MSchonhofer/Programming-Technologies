using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Presentation.API;

namespace Presentation.Model
{
    internal class ReaderModelView : IReaderModelView
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ReaderID { get; set; }
        public ReaderModelView(int id, string name, string surname)
        {
            ReaderID = id;
            Name = name;
            Surname = surname;
        }
    }
}
