using Microsoft.EntityFrameworkCore;

namespace EFCoreSample.Persistence.Context
{
    using Domain;

    public class EFSampleDBContext : DbContext
    {
        public EFSampleDBContext(string connectionString) : base(GetOptions(connectionString))
        { }


        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public DbSet<SampleDB> SampleDBs { get; set; }
    }
}
