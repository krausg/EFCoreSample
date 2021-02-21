using Microsoft.EntityFrameworkCore;

namespace EFCoreSample.Persistence.Context
{
    using Domain;

    public class EFSampleTableContext : DbContext
    {
        public EFSampleTableContext(string connectionString) : base(GetOptions(connectionString))
        { }


        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        public DbSet<SampleTable> SampleTable { get; set; }
    }
}
