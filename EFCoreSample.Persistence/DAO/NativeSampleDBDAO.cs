using System;
using System.Data.SqlClient;

namespace EFCoreSample.Persistence.DAO
{
    using EFCoreSample.Config.Properties;
    using EFCoreSample.Util.Resource;
    using Util;

    public class NativeSampleDBDAO : BaseSampleDBDAO
    {
        public NativeSampleDBDAO(string ConnectionString) : base(ConnectionString)
        {
        }

        public override void TestConnect()
        {
            SQLConnectionExecutor.ExecuteSQLNonQuery(ConnectionString, ";");
        }

        public override void ResetDB()
        {
            var resetStmt = EmbeddedResourceLoader.ReadFullContent("Scripts", "resetDB.sql");
            SQLConnectionExecutor.ExecuteSQLNonQuery(ConnectionString, resetStmt);
        }

        public override void TestSQLQuery()
        {
            SQLConnectionExecutor.ExecuteSQLQuery(ConnectionString, "select * from SAMPLETABLE").ForEach(Console.WriteLine);
        }


        public override void SelectByName(string name)
        {
            SQLConnectionExecutor.ExecuteSQLQuery(ConnectionString, "select * from SAMPLETABLE where NAME like '%" + name + "%'").ForEach(Console.WriteLine);
        }

    }

}
