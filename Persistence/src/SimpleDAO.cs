using EFCoreSample.Config;
using System;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using EFCoreSample.Util;

namespace EFCoreSample.Persistence
{

    public class SimpleDAO
    {

        private readonly SqlConnectionStringBuilder builder;

        public SimpleDAO()
        {

            builder = new SqlConnectionStringBuilder();
            builder.DataSource = AppSettings.DataSource;
            builder.UserID = AppSettings.UserID;
            builder.Password = AppSettings.Password;
            builder.InitialCatalog = AppSettings.InitialCatalog;
        }

        public void TestConnect()
        {
            SQLConnectionExecutor.ExecuteSQLNonQuery(builder.ConnectionString, ";");
        }

        public void ResetDB()
        {
            var resetStmt = EmbeddedResourceLoader.ReadFullContent("resources.scripts", "resetDB.sql");
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
