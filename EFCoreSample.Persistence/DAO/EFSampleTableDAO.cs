using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace EFCoreSample.Persistence.DAO
{
    using Context;
    using Domain;
    using EFCoreSample.Util.Resource;

    public class EFSampleTableDAO : BaseSampleTableDAO
    {

        public EFSampleTableDAO(string ConnectionString) : base(ConnectionString) { }

        public override void ResetDB()
        {
            using (EFSampleTableContext context = new EFSampleTableContext(ConnectionString))
            {
                var resetStmt = EmbeddedResourceLoader.ReadFullContent("Scripts", "resetDB.sql");
                context.Database.ExecuteSqlRaw(resetStmt);
                context.SaveChanges();

                SampleTable newEnt = new SampleTable { NAME = "Test" };
                context.SampleTable.Add(newEnt);
                context.SaveChanges();
            }

        }

        public override void SelectByName(string name)
        {
            using (EFSampleTableContext context = new EFSampleTableContext(ConnectionString))
            {
                (from t in context.SampleTable where t.NAME.Contains(name) select t).ToList().ForEach(Console.WriteLine);
            }
        }

        public override void TestConnect()
        {
            using (EFSampleTableContext context = new EFSampleTableContext(ConnectionString))
            {
                context.Database.CanConnect();
            }
        }

        public override void TestSQLQuery()
        {
            using (EFSampleTableContext context = new EFSampleTableContext(ConnectionString))
            {
                (from t in context.SampleTable select t).ToList().ForEach(Console.WriteLine);
            }
        }


    }
}
