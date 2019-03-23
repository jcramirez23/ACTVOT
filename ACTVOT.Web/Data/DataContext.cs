namespace ACTVOT.Web.Data
{
    using ACTVOT.Web.Data.Entities;
    using Microsoft.EntityFrameworkCore;
    public class DataContext : DbContext
    {

        public DbSet<ActVote> ActVotes { get; set; }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

    }
}
