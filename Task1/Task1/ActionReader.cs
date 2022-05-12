using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public abstract class ActionReader : IAction
    {
        protected DateTime dateTime;
        public IReader Reader { get; set; }
        public ActionReader(DateTime date, IReader reader)
        {
            dateTime = date;
            Reader = reader;
        }

        public DateTime GetDateTime()
        {
            return dateTime;
        }

        public abstract ActionType GetActionType();
    }

    public class AddReader : ActionReader
    {
        public AddReader(DateTime date, IReader reader) : base(date, reader) { }
        public override ActionType GetActionType()
        {
            return ActionType.AddReader;
        }
    }

    public class UpdateReader : ActionReader
    {
        public UpdateReader(DateTime date, IReader reader) : base (date, reader) { }

        public override ActionType GetActionType()
        {
            return ActionType.UpdateReader;
        }
    }

    public class DeleteReader : ActionReader
    {
        public DeleteReader(DateTime date, IReader reader) : base(date, reader) { }
        public override ActionType GetActionType()
        {
            return ActionType.DeleteReader;
        }
    }
}
