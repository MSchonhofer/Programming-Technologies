using System;
using System.Collections.Generic;
using System.Text;

namespace Data
{
    public class DataLibrary
    {
        public class DataSet
        {
            public int ValidBookID { get; set; }
            public List<Reader> Readers { get; set; }
            public List<Catalog> Catalogs { get; set; }
            public List<IAction> Actions { get; set; }

            public DataSet()
            {
                Readers = new List<Reader>();
                Catalogs = new List<Catalog>();
                Actions = new List<IAction>();
                ValidBookID = 0;
            }
        }

        private DataSet data { get; set; }
        private IFill filler;

    public DataLibrary(IAction action)
    {
        data = new DataSet();
        // this.filler = filler;
        this.filler.Fill(this);
    }
    }
}
