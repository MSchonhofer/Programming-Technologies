using System.Collections.Generic;


namespace Data.API
{
    public interface ICatalog
    {
        string Author { get; set; }
        string Title { get; set; }
        List<IBook> Books { get; set; }

    }
}
