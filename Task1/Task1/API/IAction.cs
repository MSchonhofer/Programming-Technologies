using System;

namespace Data.API
{
    public enum ActionType
    {
        AddBook, RentBook, DeleteBook, ReturnBook,
        AddCatalog, UpdateCatalog, DeleteCatalog,
        AddReader, UpdateReader, DeleteReader
    }
    public interface IAction
    {
        ActionType GetActionType();
        DateTime GetDateTime();
    }
}
