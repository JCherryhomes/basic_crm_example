using CRM_Example.Models;
using System.Threading.Tasks;
using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Identity;
using System.Collections.Immutable;
using System.Linq;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace CRM_Example.Data
{
    internal class SampleData
    {
        private static readonly ApplicationUser admin = new ApplicationUser
        {
            FirstName = "The",
            LastName = "Admin",
            Email = "admin@admin.com",
            NormalizedEmail = "ADMIN@ADMIN.COM",
            UserName = "admin@admin.com",
            NormalizedUserName = "ADMIN",
            EmailConfirmed = true,
            PhoneNumber = "1111111111",
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D")
        };

        private static readonly ApplicationUser user = new ApplicationUser
        {
            FirstName = "First",
            LastName = "User",
            Email = "user@user.com",
            NormalizedEmail = "USER@USER.COM",
            UserName = "user@user.com",
            NormalizedUserName = "USER",
            EmailConfirmed = true,
            PhoneNumber = "2222222222",
            PhoneNumberConfirmed = true,
            SecurityStamp = Guid.NewGuid().ToString("D")
        };

        #region Customers
        private static ImmutableList<Customer> Customers = ImmutableList.Create(
                   new Customer {
                       FirstName = "Priscilla",
                       LastName = "Lenden"
                   }, new Customer {
                       FirstName = "Nita",
                       LastName = "Rollo"
                   }, new Customer {
                       FirstName = "Sacha",
                       LastName = "Thomas"
                   }, new Customer {                       
                       FirstName = "Norman",
                       LastName = "Anneslie"
                   }, new Customer {                       
                       FirstName = "Lurette",
                       LastName = "Keysall"
                   }, new Customer {                       
                       FirstName = "Romeo",
                       LastName = "Milby"
                   }, new Customer {                       
                       FirstName = "Shaylynn",
                       LastName = "Gumby"
                   }, new Customer {                       
                       FirstName = "Francisco",
                       LastName = "De Roeck"
                   }, new Customer {                       
                       FirstName = "Stanislas",
                       LastName = "MacSherry"
                   }, new Customer {                       
                       FirstName = "Rey",
                       LastName = "Birtwisle"
                   }, new Customer {                       
                       FirstName = "Leighton",
                       LastName = "Sicily"
                   }, new Customer {                       
                       FirstName = "Yves",
                       LastName = "Donaher"
                   }, new Customer {                       
                       FirstName = "Josy",
                       LastName = "McSperrin"
                   }, new Customer {                       
                       FirstName = "Amory",
                       LastName = "Pacht"
                   }, new Customer {                       
                       FirstName = "Coop",
                       LastName = "Butchers"
                   }, new Customer {                       
                       FirstName = "Zacharia",
                       LastName = "Leishman"
                   }, new Customer {                       
                       FirstName = "Gwendolin",
                       LastName = "Pond-Jones"
                   }, new Customer {                       
                       FirstName = "Florette",
                       LastName = "Stennings"
                   }, new Customer {                       
                       FirstName = "Caesar",
                       LastName = "Gehricke"
                   }, new Customer {                       
                       FirstName = "Korney",
                       LastName = "Ditt"
                   }, new Customer {                       
                       FirstName = "Veronica",
                       LastName = "Kunzler"
                   }, new Customer {                       
                       FirstName = "Obidiah",
                       LastName = "Goracci"
                   }, new Customer {                       
                       FirstName = "Tomlin",
                       LastName = "Banting"
                   }, new Customer {                       
                       FirstName = "Ailyn",
                       LastName = "Krabbe"
                   }, new Customer {                       
                       FirstName = "Xenia",
                       LastName = "Blaylock"
                   }, new Customer {                       
                       FirstName = "Willetta",
                       LastName = "Dines"
                   }, new Customer {                       
                       FirstName = "Rorie",
                       LastName = "Flewin"
                   }, new Customer {
                       FirstName = "Hesther",
                       LastName = "Temporal"
                   }, new Customer {                       
                       FirstName = "Lane",
                       LastName = "Crowdace"
                   }, new Customer {                       
                       FirstName = "Elvis",
                       LastName = "Penylton"
                   }, new Customer {                       
                       FirstName = "Rheba",
                       LastName = "Morphey"
                   }, new Customer {                       
                       FirstName = "Roseline",
                       LastName = "Danis"
                   }, new Customer {                       
                       FirstName = "Skipp",
                       LastName = "Willoughway"
                   }, new Customer {                       
                       FirstName = "Aridatha",
                       LastName = "Borrington"
                   }, new Customer {                       
                       FirstName = "Karim",
                       LastName = "Basketter"
                   }, new Customer {                       
                       FirstName = "Ludovika",
                       LastName = "Nutkin"
                   }, new Customer {                       
                       FirstName = "Rutger",
                       LastName = "Jacomb"
                   }, new Customer {                       
                       FirstName = "Zitella",
                       LastName = "Gillani"
                   }, new Customer {                       
                       FirstName = "Fidelia",
                       LastName = "Gow"
                   }, new Customer {                       
                       FirstName = "Sylvester",
                       LastName = "Boulton"
                   }, new Customer {                       
                       FirstName = "Rozalie",
                       LastName = "Smallbone"
                   }, new Customer {                       
                       FirstName = "Matilda",
                       LastName = "Beavan"
                   }, new Customer {                       
                       FirstName = "Camellia",
                       LastName = "Furlow"
                   }, new Customer {                       
                       FirstName = "Pernell",
                       LastName = "Sanper"
                   }, new Customer {                       
                       FirstName = "Elicia",
                       LastName = "Marlon"
                   }, new Customer {                       
                       FirstName = "Alvin",
                       LastName = "Mallard"
                   }, new Customer {                       
                       FirstName = "Silvan",
                       LastName = "Dioniso"
                   }, new Customer {                       
                       FirstName = "Bud",
                       LastName = "Roles"
                   }, new Customer {                       
                       FirstName = "Yulma",
                       LastName = "Perry"
                   }, new Customer {                       
                       FirstName = "Dacie",
                       LastName = "Gino"
                   }, new Customer {                       
                       FirstName = "Tailor",
                       LastName = "Dominicacci"
                   }, new Customer {                       
                       FirstName = "Eran",
                       LastName = "Beamson"
                   }, new Customer {                       
                       FirstName = "Allegra",
                       LastName = "Mulbry"
                   }, new Customer {                       
                       FirstName = "Susann",
                       LastName = "Shoreson"
                   }, new Customer {                       
                       FirstName = "Almeta",
                       LastName = "Sharply"
                   }, new Customer {                       
                       FirstName = "Elmore",
                       LastName = "Farrent"
                   }, new Customer {                       
                       FirstName = "Blinni",
                       LastName = "Heel"
                   }, new Customer {                       
                       FirstName = "Caresse",
                       LastName = "Lanahan"
                   }, new Customer {                       
                       FirstName = "Karina",
                       LastName = "Poag"
                   }, new Customer {                       
                       FirstName = "Reggi",
                       LastName = "Towsey"
                   }, new Customer {                       
                       FirstName = "Mikael",
                       LastName = "Boc"
                   }, new Customer {                       
                       FirstName = "Maximilien",
                       LastName = "MacCaig"
                   }, new Customer {                       
                       FirstName = "Sayer",
                       LastName = "Luckett"
                   }, new Customer {                       
                       FirstName = "Heath",
                       LastName = "Licciardiello"
                   }, new Customer {                       
                       FirstName = "Walton",
                       LastName = "Danovich"
                   }, new Customer {                       
                       FirstName = "Armin",
                       LastName = "Clausson"
                   }, new Customer {                       
                       FirstName = "Babette",
                       LastName = "Whitcomb"
                   }, new Customer {                       
                       FirstName = "Kory",
                       LastName = "Stoyles"
                   }, new Customer {                       
                       FirstName = "Andriana",
                       LastName = "Pimblott"
                   }, new Customer {                       
                       FirstName = "Minta",
                       LastName = "Batter"
                   }, new Customer {                       
                       FirstName = "Lucita",
                       LastName = "Comini"
                   }, new Customer {                       
                       FirstName = "Austina",
                       LastName = "Donat"
                   }, new Customer {                       
                       FirstName = "Dani",
                       LastName = "Briatt"
                   }, new Customer {                       
                       FirstName = "Ruthie",
                       LastName = "Friman"
                   }, new Customer {                       
                       FirstName = "Adolph",
                       LastName = "Sirey"
                   }, new Customer {                       
                       FirstName = "Avigdor",
                       LastName = "Swalwell"
                   }, new Customer {                       
                       FirstName = "Dasha",
                       LastName = "Barnshaw"
                   }, new Customer {                       
                       FirstName = "Dorita",
                       LastName = "Gisburn"
                   }, new Customer {                       
                       FirstName = "Dorita",
                       LastName = "Christy"
                   }, new Customer {                       
                       FirstName = "Stevena",
                       LastName = "Feye"
                   }, new Customer {                       
                       FirstName = "Stevana",
                       LastName = "Girardey"
                   }, new Customer {                       
                       FirstName = "Aubert",
                       LastName = "Swanwick"
                   }, new Customer {                       
                       FirstName = "Lona",
                       LastName = "Vairow"
                   }, new Customer {                       
                       FirstName = "Phedra",
                       LastName = "Dukelow"
                   }, new Customer {                       
                       FirstName = "Reider",
                       LastName = "Janku"
                   }, new Customer {                       
                       FirstName = "Alica",
                       LastName = "Culleford"
                   }, new Customer {                       
                       FirstName = "Michal",
                       LastName = "Forlonge"
                   }, new Customer {                       
                       FirstName = "Constantine",
                       LastName = "Aldie"
                   }, new Customer {                       
                       FirstName = "Danita",
                       LastName = "Ahrend"
                   }, new Customer {                       
                       FirstName = "Clarette",
                       LastName = "Effaunt"
                   }, new Customer {                       
                       FirstName = "Nessy",
                       LastName = "Hovington"
                   }, new Customer {                       
                       FirstName = "Rafi",
                       LastName = "Float"
                   }, new Customer {                       
                       FirstName = "Tatiana",
                       LastName = "Claque"
                   }, new Customer {                       
                       FirstName = "Liz",
                       LastName = "Crossby"
                   }, new Customer {                       
                       FirstName = "Donnie",
                       LastName = "Tumber"
                   }, new Customer {                       
                       FirstName = "Pincus",
                       LastName = "Costain"
                   }, new Customer {
                       FirstName = "Angel",
                       LastName = "Mumbray"
                   }, new Customer {                       
                       FirstName = "Barr",
                       LastName = "Cesaric"
                   }, new Customer {                       
                       FirstName = "Norry",
                       LastName = "McKane"
                   }, new Customer {                       
                       FirstName = "Bailie",
                       LastName = "Le Grove"
                   });
        #endregion

        public static async Task Initialize(IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            SeedCustomers(context);
            await SeedRoles(context);
            await SeedApplicationUsers(serviceProvider, context);

            AssignRoles(context);
                
            await context.SaveChangesAsync();
        }

        private static void SeedCustomers(ApplicationDbContext context)
        {
            var exists = context.Customers.Any();

            if (!exists)
            {
                Customers.ForEach(customer => context.Customers.Add(customer));
            }
        }

        private static async Task SeedRoles(ApplicationDbContext context)
        {
            var roleStore = new RoleStore<IdentityRole>(context);
            roleStore.AutoSaveChanges = false;

            if (!context.Roles.Any(role => role.Name == Roles.Admin))
            {
                await roleStore.CreateAsync(new IdentityRole(Roles.Admin));
            }

            if (!context.Roles.Any(role => role.Name == Roles.User))
            {
                await roleStore.CreateAsync(new IdentityRole(Roles.User));
            }
        }

        private static async Task SeedApplicationUsers(IServiceProvider serviceProvider, ApplicationDbContext context)
        {
            var userStore = new UserStore<ApplicationUser>(context);
            userStore.AutoSaveChanges = false;

            await AddAdminWithRole(serviceProvider, context, userStore);
            await AddFirstUserWithRole(serviceProvider, context, userStore);
        }

        private static async Task AddFirstUserWithRole(IServiceProvider serviceProvider, ApplicationDbContext context, UserStore<ApplicationUser> userStore)
        {
            if (!context.Users.Any(u => u.UserName == user.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(user, "password");
                user.PasswordHash = hashed;

                await userStore.CreateAsync(user);
            }
        }

        private static async Task<ApplicationUser> AddAdminWithRole(IServiceProvider serviceProvider, ApplicationDbContext context, UserStore<ApplicationUser> userStore)
        {           

            if (!context.Users.Any(u => u.UserName == admin.UserName))
            {
                var password = new PasswordHasher<ApplicationUser>();
                var hashed = password.HashPassword(admin, "admin");
                admin.PasswordHash = hashed;

                await userStore.CreateAsync(admin);
            }

            return admin;
        }

        private static void AssignRoles(ApplicationDbContext context)
        {
            var userRole = context.Roles.SingleOrDefault(role => role.Name == Roles.User);
            var adminRole = context.Roles.SingleOrDefault(role => role.Name == Roles.Admin);

            var applicationUser = context.Users.SingleOrDefault(u => u.UserName == user.UserName);
            var applicationAdmin = context.Users.SingleOrDefault(u => u.UserName == admin.UserName);

            var shouldAddUserRole = !context.UserRoles.Any(r => r.RoleId == userRole.Id && r.UserId == applicationUser.Id);
            var shouldAddAdminRole = !context.UserRoles.Any(r => r.RoleId == adminRole.Id && r.UserId == applicationAdmin.Id);

            if (shouldAddUserRole)
            {
                context.UserRoles.Add(new IdentityUserRole<string> { RoleId = userRole.Id, UserId = applicationUser.Id });
            }

            if (shouldAddAdminRole)
            {
                context.UserRoles.Add(new IdentityUserRole<string> { RoleId = adminRole.Id, UserId = applicationAdmin.Id });
            }
        }
    }
}