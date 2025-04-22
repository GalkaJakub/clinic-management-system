using Clinic.Data;
using Clinic.Models;
using Clinic.Models.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Clinic.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class UsersController : Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;
        private readonly UserManager<ApplicationUser> userManager;

        public UsersController(RoleManager<IdentityRole> roleManager, UserManager<ApplicationUser> _userManager)
        {
            this.roleManager = roleManager;
            userManager = _userManager;
        }

        public async Task<IActionResult> Index()
        {
            var users = userManager.Users.Include(x => x.Doctor).ToList();
            var model = new List<UserWithRole>();
            foreach (var user in users)
            {
                var role = await userManager.GetRolesAsync(user);
                if (!role.IsNullOrEmpty())
                {
                    model.Add(new UserWithRole
                    {
                        User = user,
                        Role = role.First()
                    });
                }
                else
                {
                    model.Add(new UserWithRole
                    {
                        User = user,
                        Role = " - "
                    });
                }
            }
            return View(model);
        }
    }
}
