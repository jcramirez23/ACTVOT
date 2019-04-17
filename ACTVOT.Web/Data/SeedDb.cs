namespace ACTVOT.Web.Data
{
    using System;
    using System.Linq;
    using System.Threading.Tasks;
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using ACTVOT.Web.Helpers;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();


            var user = await this.userHelper.GetUserByEmailAsync("jcamilor.454@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Juan",
                    LastName = "Ramirez",
                    Email = "jcamilor.454@gmail.com",
                    UserName = "jcamilor.454@gmail.com",
                    PhoneNumber = "3194114289"
                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }
            }

            if (!this.context.ActVotes.Any())
            {
                this.AddEvent("presidencials", user);
                this.AddEvent("generic", user);
                this.AddEvent("personers", user);
                await this.context.SaveChangesAsync();
            }
        }

        private void AddEvent(string name, User user)
        {
            this.context.ActVotes.Add(new ActVote
            {
                Name = name,
                Description = "Descrition here",
                Actstar = DateTime.Today,
                Endstar = DateTime.Today,
                user = user
            });
        }



    }

}
