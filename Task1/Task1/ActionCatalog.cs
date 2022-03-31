using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public abstract class ActionCatalog : IAction
    {
        protected DateTime dateTime;
        public Catalog Catalog { get; set; }
        public ActionCatalog(DateTime date, Catalog catalog)
        {
            dateTime = date;
            Catalog = catalog;
        }

        public DateTime GetDateTime()
        {
            return dateTime;
        }

        public abstract ActionType GetActionType();
    }

    public class AddCatalog : ActionCatalog
    {
        public AddCatalog(DateTime date, Catalog catalog) : base(date, catalog) { }

        public override ActionType GetActionType()
        {
            return ActionType.AddCatalog;
        }
    }

    public class UpdateCatalog : ActionCatalog
    {
        public UpdateCatalog(DateTime date, Catalog catalog) : base(date, catalog) { }

        public override ActionType GetActionType()
        {
            return ActionType.UpdateCatalog;
        }
    }

    public class DeleteCatalog : ActionCatalog
    {
        public DeleteCatalog(DateTime date, Catalog catalog) : base(date, catalog) { }

        public override ActionType GetActionType()
        {
            return ActionType.DeleteCatalog;
        }
    }
}
