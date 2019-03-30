namespace ACTVOT.Web.Data
{
    
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;


    public class SeedDb
    {
        private readonly DataContext context;
        private Random random;

        public SeedDb(DataContext context)
        {
            this.context = context;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            if (!this.context.ActVotes.Any())
            {
                this.AddActvote("Precidencials");
                this.AddActvote("alcaldes");
                this.AddActvote("senado");
                await this.context.SaveChangesAsync();
            }
        }

        private void AddActvote(string name)
        {
            this.context.ActVotes.Add(new ActVote
            {
                Name = name,
                Actstar = DateTime.Today,
                Endstar = DateTime.Today,
                Description = "Insert Description"
            });
        }
    }

}
