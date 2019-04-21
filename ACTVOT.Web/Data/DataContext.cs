namespace ACTVOT.Web.Data
{
    using ACTVOT.Web.Data.Entities;
    using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
    using Microsoft.EntityFrameworkCore;
    public class DataContext : IdentityDbContext<User>

    {
        public DbSet<ActVote> ActVotes { get; set; }

        public DbSet<Country> Countries { get; set; }

        public DbSet<Candidates> Candidates { get; set; }


        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
         
    }
}
