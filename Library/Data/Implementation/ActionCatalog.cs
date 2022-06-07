using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Data.API;

namespace Data.Impl
{
    public abstract class ActionCatalog : IAction
    {
        protected DateTime dateTime;
        public ICatalog Catalog { get; set; }
        public ActionCatalog(DateTime date, ICatalog catalog)
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
        public AddCatalog(DateTime date, ICatalog catalog) : base(date, catalog) { }

        public override ActionType GetActionType()
        {
            return ActionType.AddCatalog;
        }
    }

    public class UpdateCatalog : ActionCatalog
    {
        public UpdateCatalog(DateTime date, ICatalog catalog) : base(date, catalog) { }

        public override ActionType GetActionType()
        {
            return ActionType.UpdateCatalog;
        }
    }

    public class DeleteCatalog : ActionCatalog
    {
        public DeleteCatalog(DateTime date, ICatalog catalog) : base(date, catalog) { }

        public override ActionType GetActionType()
        {
            return ActionType.DeleteCatalog;
        }
    }
}
