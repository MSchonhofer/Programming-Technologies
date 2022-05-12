using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public abstract class ActionBook : IAction
    {
        protected DateTime dateTime;
        public IBook Book { get; set; }
        public ActionBook(DateTime date, IBook book)
        {
            dateTime = date;
            Book = book;
        }

        public DateTime GetDateTime()
        {
            return dateTime;
        }

        public abstract ActionType GetActionType();
    }

    public class AddBook : ActionBook
    {
        public AddBook(DateTime date, IBook book) : base(date, book) { }
        public override ActionType GetActionType()
        {
            return ActionType.AddBook;
        }
    }

    internal class RentBook : ActionBook, IRentBook
    {
        public IReader Reader { get; set; }
        public RentBook(DateTime date, IBook book, IReader reader) : base(date, book) 
        {
            Reader = reader;
        }
        public override ActionType GetActionType()
        {
            return ActionType.RentBook;
        }
    }

    internal class ReturnBook : ActionBook, IReturnBook
    {
        public IReader Reader { get; set; }
        public ReturnBook(DateTime date, IBook book, IReader reader) : base(date, book)
        {
            Reader = reader;
        }
        public override ActionType GetActionType()
        {
            return ActionType.ReturnBook;
        }
    }

    public class DeleteBook : ActionBook
    {
        public DeleteBook(DateTime date, IBook book) : base(date, book) { }
        public override ActionType GetActionType()
        {
            return ActionType.DeleteBook;
        }
    }
}
