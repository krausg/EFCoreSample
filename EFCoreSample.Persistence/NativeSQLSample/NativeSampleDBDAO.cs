using System;
using System.Data.SqlClient;

namespace EFCoreSample.Persistence.NativeSQLSample
{
    using EFCoreSample.Config.Properties;
    using EFCoreSample.Util.Resource;
    using Util;

    public class NativeSampleDBDAO
    {

        private readonly SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = Resources.DataSource,
            UserID = Resources.UserID,
            Password = Resources.Password,
            InitialCatalog = Resources.InitialCatalog
        };

        public NativeSampleDBDAO()
        { }

        public void TestConnect()
        {
            SQLConnectionExecutor.ExecuteSQLNonQuery(builder.ConnectionString, ";");
        }

        public void ResetDB()
        {
            var resetStmt = EmbeddedResourceLoader.ReadFullContent("Scripts", "resetDB.sql");
            SQLConnectionExecutor.ExecuteSQLNonQuery(builder.ConnectionString, resetStmt);
        }

        public void TestSQLQuery()
        {
            SQLConnectionExecutor.ExecuteSQLQuery(builder.ConnectionString, "select * from SAMPLETABLE").ForEach(Console.WriteLine);
        }


        public void SelectByName(string name)
        {
            SQLConnectionExecutor.ExecuteSQLQuery(builder.ConnectionString, "select * from SAMPLETABLE where NAME like '%" + name + "%'").ForEach(Console.WriteLine);
        }

    }

}
