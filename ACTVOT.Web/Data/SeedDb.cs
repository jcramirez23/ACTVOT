namespace ACTVOT.Web.Data
{
    using ACTVOT.Web.Helpers;
    using Entities;
    using Microsoft.AspNetCore.Identity;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    public class SeedDb
    {
        private readonly DataContext context;
        private readonly IUserHelper userHelper;
        private readonly Random random;

        public SeedDb(DataContext context, IUserHelper userHelper)
        {
            this.context = context;
            this.userHelper = userHelper;
            this.random = new Random();
        }

        public async Task SeedAsync()
        {
            await this.context.Database.EnsureCreatedAsync();

            await this.userHelper.CheckRoleAsync("Admin");
            await this.userHelper.CheckRoleAsync("Customer");

            if (!this.context.Countries.Any())
            {
                var cities = new List<City>();
                cities.Add(new City { Name = "Medellín" });
                cities.Add(new City { Name = "Bogotá" });
                cities.Add(new City { Name = "Calí" });

                this.context.Countries.Add(new Country
                {
                    Cities = cities,
                    Name = "Colombia"
                });

                await this.context.SaveChangesAsync();
            }



            var user = await this.userHelper.GetUserByEmailAsync("jcamilor.454@gmail.com");
            if (user == null)
            {
                user = new User
                {
                    FirstName = "Juan",
                    LastName = "Ramirez",
                    Email = "jcamilor.454@gmail.com",
                    UserName = "jcamilor.454@gmail.com",
                    PhoneNumber = "3194114289",
                    Address = "Calle Luna Calle Sol",
                    CityId = this.context.Countries.FirstOrDefault().Cities.FirstOrDefault().Id,
                    City = this.context.Countries.FirstOrDefault().Cities.FirstOrDefault()

                };

                var result = await this.userHelper.AddUserAsync(user, "123456");
                if (result != IdentityResult.Success)
                {
                    throw new InvalidOperationException("Could not create the user in seeder");
                }

                await this.userHelper.AddUserToRoleAsync(user, "Admin");
                var token = await this.userHelper.GenerateEmailConfirmationTokenAsync(user);
                await this.userHelper.ConfirmEmailAsync(user, token);

            }
            var isInRole = await this.userHelper.IsUserInRoleAsync(user, "Admin");
            if (!isInRole)
            {
                await this.userHelper.AddUserToRoleAsync(user, "Admin");
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
