using Data.API;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presentation.Model.Implementation
{
    public class ReaderModelView : IReaderModelView
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public int ReaderID { get; set; }
        public List<IBook> Books { get; set; }
        public ReaderModelView(string name, string surname, int id)
        {
            Name = name;
            Surname = surname;
            ReaderID = id;
            Books = new List<IBook>();
        }
    }
}
