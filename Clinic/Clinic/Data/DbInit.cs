using Clinic.Models;
using Microsoft.AspNetCore.Identity;

namespace Clinic.Data
{
    public class DbInit
    {
        public static async Task AdminInit(IServiceProvider serviceProvider)
        {
            var userManager = serviceProvider.GetRequiredService<UserManager<ApplicationUser>>();
            var dbContext = serviceProvider.GetRequiredService<ApplicationDbContext>();

            string email = "admin@admin.com";
            string password = "AdminAdmin1!";
            string roleName = "Admin";

            var user = await userManager.FindByEmailAsync(email);
            if (user == null)
            {
                user = new ApplicationUser
                {
                    UserName = email,
                    Email = email,
                    Name = "Admin",
                    Surname = "Admin"
                };
                await userManager.CreateAsync(user, password);
            }

            if (!await userManager.IsInRoleAsync(user, roleName))
            {
                await userManager.AddToRoleAsync(user, roleName);
            }

            if (!dbContext.Admins.Any(a => a.ApplicationUserId == user.Id))
            {
                dbContext.Admins.Add(new Admin { ApplicationUserId = user.Id });
                dbContext.SaveChanges();
            }
        }

    }
}
