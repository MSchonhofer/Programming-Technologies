namespace Data.API
{
    public interface IBook
    {
        ICatalog Catalog { get; set; }
        int BookID { get; set; }
        
    }
}
