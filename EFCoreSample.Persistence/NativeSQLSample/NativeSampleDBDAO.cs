using System;
using System.Data.SqlClient;

namespace EFCoreSample.Persistence.NativeSQLSample
{
    using EFCoreSample.Config.AppSettings;
    using EFCoreSample.Util.Resource;
    using Util;

    public class NativeSampleDBDAO
    {

        private readonly SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
        {
            DataSource = AppSettings.DataSource,
            UserID = AppSettings.UserID,
            Password = AppSettings.Password,
            InitialCatalog = AppSettings.InitialCatalog
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
