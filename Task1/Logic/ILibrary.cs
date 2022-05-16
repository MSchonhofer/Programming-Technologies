using Data.API;
using Logic;

namespace Logic.API
{

    public abstract class ILibrary
    {
        public abstract void RentBook(string author, string title, IReader reader);
        public abstract void ReturnBook(IBook book, IReader reader);


        public static ILibrary CreateLogic(IDataRepository? dataRepository = default)

        {
            return new Library(dataRepository ?? IDataRepository.CreateDataRepository());
        }

    }
}