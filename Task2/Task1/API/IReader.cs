using System.Collections.Generic;

namespace Data.API
{
    public interface IReader
    {
        string Name { get; set; }
        string Surname { get; set; }
        int ReaderID { get; set; }
        List<IBook> Books { get; set; }

    }
}
