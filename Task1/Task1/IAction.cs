using System;
using System.Collections.Generic;
using System.Text;

namespace Data
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
