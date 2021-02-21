using System;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.Data.SqlClient;

namespace EFCoreSample.Persistence.DAO
{
    using Context;
    using Domain;
    using EFCoreSample.Util.Resource;

    public class EFSampleDBDAO : BaseSampleDBDAO
    {

        public EFSampleDBDAO(string ConnectionString) : base(ConnectionString) { }

        public override void ResetDB()
        {
            using (EFSampleDBContext context = new EFSampleDBContext(ConnectionString))
            {
                var resetStmt = EmbeddedResourceLoader.ReadFullContent("Scripts", "resetDB.sql");
                context.Database.ExecuteSqlRaw(resetStmt);
                context.SaveChanges();

                SampleDB newEnt = new SampleDB { Name = "Test" };
                context.SampleDBs.Add(newEnt);
                context.SaveChanges();
            }

        }

        public override void SelectByName(string name)
        {
            using (EFSampleDBContext context = new EFSampleDBContext(ConnectionString))
            {
                (from t in context.SampleDBs where t.Name.Contains(name) select t).ToList().ForEach(Console.WriteLine);
            }
        }

        public override void TestConnect()
        {
            using (EFSampleDBContext context = new EFSampleDBContext(ConnectionString))
            {
                context.Database.CanConnect();
            }
        }

        public override void TestSQLQuery()
        {
            using (EFSampleDBContext context = new EFSampleDBContext(ConnectionString))
            {
                (from t in context.SampleDBs select t).ToList().ForEach(Console.WriteLine);
            }
        }


    }
}
