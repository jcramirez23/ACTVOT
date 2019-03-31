namespace ACTVOT.Web.Data
{
    
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Helpers;
    using Microsoft.AspNetCore.Identity;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            var user = await this.userHelper.GetUserByEmailAsync("jcamilo.454@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Juan",
                    LastName = "Ramirez",
                    Email = "jcamilo.454@gmail.com",
                    UserName = "jcamilo.454@gmail.com", 
                    PhoneNumber="3194114289"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }   
            }

            if (!this.context.ActVotes.Any())
            {
                this.AddActvote("Precidencials", user);
                this.AddActvote("alcaldes", user);
                this.AddActvote("senado", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddActvote(string name, User user)
        {
            this.context.ActVotes.Add(new ActVote
            {
                Name = name,
                Actstar = DateTime.Today,
                Endstar = DateTime.Today,
                Description = "Insert Description",
                user= user
            });
        }
    }

}
