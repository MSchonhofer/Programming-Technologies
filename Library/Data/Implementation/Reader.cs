using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace Data.Impl
{
    internal class Reader : IReader
    {
        public int ReaderID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public Reader(int readerID, string name, string surname)
        {
            ReaderID = readerID;
            Name = name;
            Surname = surname;
        }
    }
}
