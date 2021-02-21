using System;
using System.Collections.Generic;
using System.Text;

namespace EFCoreSample.Persistence.DAO
{
    public abstract class BaseSampleDBDAO
    {

        internal string ConnectionString { get; }

        public BaseSampleDBDAO(string ConnectionString)
        {
            this.ConnectionString = ConnectionString;
        }

        public abstract void TestConnect();
        public abstract void ResetDB();
        public abstract void TestSQLQuery();
        public abstract void SelectByName(string name);
    }
}
