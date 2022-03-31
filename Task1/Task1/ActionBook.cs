using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public abstract class ActionBook : IAction
    {
        protected DateTime dateTime;
        public Book Book { get; set; }
        public ActionBook(DateTime date, Book book)
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
        public AddBook(DateTime date, Book book) : base(date, book) { }
        public override ActionType GetActionType()
        {
            return ActionType.AddBook;
        }
    }

    public class RentBook : ActionBook
    {
        public Reader Reader { get; set; }
        public RentBook(DateTime date, Book book, Reader reader) : base(date, book) 
        {
            Reader = reader;
        }
        public override ActionType GetActionType()
        {
            return ActionType.RentBook;
        }
    }

    public class ReturnBook : ActionBook
    {
        public Reader Reader { get; set; }
        public ReturnBook(DateTime date, Book book, Reader reader) : base(date, book)
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
        public DeleteBook(DateTime date, Book book) : base(date, book) { }
        public override ActionType GetActionType()
        {
            return ActionType.DeleteBook;
        }
    }
}
