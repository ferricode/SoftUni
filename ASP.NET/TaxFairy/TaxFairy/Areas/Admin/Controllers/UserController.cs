using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using TaxFairy.Core.Constants;
using TaxFairy.Core.Contracts;
using TaxFairy.Core.ViewModels;
using TaxFairy.Infrastructure.Data.Identity;

namespace TaxFairy.Areas.Admin.Controllers
{
   [Authorize(Roles = UserConstants.Roles.Administrator)]
   [Area("Admin")]
    public class UserController:Controller
    {
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<ApplicationUser> userManager;

        private IUserService service;
        public UserController(
            RoleManager<IdentityRole> _roleManager,
            UserManager<ApplicationUser> _userManager,
            IUserService _service)
        {
            roleManager = _roleManager;
            userManager = _userManager;
            service = _service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ManageUsers()
        {
            var users = await service.GetUsersList();
            return View(users);
        }
        public async Task<IActionResult> Roles(string id)
        {
            var user = userManager.Users.Where(x => x.Id == id).FirstOrDefault();
            var model = new UserRolesViewModel()
            {
                UserId = user.Id,
                UserName = user.UserName,
            };


            ViewBag.RoleItems = roleManager.Roles
                  .ToList()
                  .Select(r => new SelectListItem()
                  {
                      Text = r.Name,
                      Value = r.Id,
                      Selected = userManager.IsInRoleAsync(user, r.Name).Result
                  })
                  .ToList();

            return View(model);
        }
        public async Task<IActionResult> Edit(string id)
        {
            var model = await service.GetUserToEdit(id);

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await service.EditUser(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "Промените бяха записани успешно.";
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Възникна грешка!";
            }
               return View(model);


        }
        public async Task<IActionResult> CreateRole(string roleName)
        {
            await roleManager.CreateAsync(new IdentityRole()
            {
                Name = roleName
            });

            return Ok();
        }
    }
}
