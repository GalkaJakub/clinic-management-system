using Clinic.Data;
using Clinic.Models;
using Clinic.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace Clinic.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = SD.Role_Admin)]
    public class UsersController : Controller
    {
        private readonly UserManager<ApplicationUser> userManager;
        private readonly ApplicationDbContext db;

        public UsersController(UserManager<ApplicationUser> userManager, ApplicationDbContext db)
        {
            this.userManager = userManager;
            this.db = db;
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
        public IActionResult CreateUser()
        {
            return RedirectToPage("/Account/Register", new { area = "Identity" });
        }

        public async Task<ActionResult> DeleteUser(string userId)
        {
            var user = await userManager.FindByIdAsync(userId);
            if (user != null)
            {
                await userManager.DeleteAsync(user);
                return RedirectToAction(nameof(Index));
            }
            return View();
            
        }

        public IActionResult UpdateUser(string userId)
        {
            var user = db.Users.Include(x => x.Doctor).FirstOrDefault(x => x.Id == userId);
            return View(user);
        }

        [HttpPost]
        public async Task<ActionResult> UpdateUser(ApplicationUser user)
        {
            if (ModelState.IsValid)
            {
                var updatedUser = db.Users.Include(x => x.Doctor).FirstOrDefault(x => x.Id == user.Id);
                if (updatedUser != null)
                {
                    updatedUser.Name = user.Name;
                    updatedUser.Surname = user.Surname;
                    updatedUser.Email = user.Email;
                    updatedUser.UserName = user.UserName;
                    
                    if(user.Doctor != null)
                    {
                        updatedUser.Doctor.NPWZ = user.Doctor.NPWZ;
                    }

                    await userManager.UpdateAsync(updatedUser);
                    return RedirectToAction(nameof(Index));
                }
            }

            return View(user);

        }

    }
}
