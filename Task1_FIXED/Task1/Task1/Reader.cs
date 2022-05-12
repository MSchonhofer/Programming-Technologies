using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    internal class Reader
    {
        public int ReaderID { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public List<IBook> Books { get; set; }
        public Reader(int readerID, string name, string surname)
        {
            ReaderID = readerID;
            Name = name;
            Surname = surname;
            Books = new List<IBook>();
        }
    }
}
