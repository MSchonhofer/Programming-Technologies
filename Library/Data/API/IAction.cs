using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
