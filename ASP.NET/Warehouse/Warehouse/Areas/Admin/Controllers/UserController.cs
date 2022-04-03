using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Warehouse.Core.Constants;
using Warehouse.Core.Contracts;
using Warehouse.Core.Models;
using Warehouse.Infrastructure.Data.Identity;

namespace Warehouse.Areas.Admin.Controllers
{
    public class UserController : BaseController
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
            var users = await service.GetUsers();
            return View(users);
        }
        public async Task<IActionResult> Roles(string id)
        {
            var user = userManager.Users.Where(x => x.Id == id).FirstOrDefault(); 
            var model = new UserRolesViewModel()
            {
                UserId = user.Id,
                Name = $"{user.FirstName} {user.LastName}"
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
            var model = await service.GetUserForEdit(id);

            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Edit(UserEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await service.UpdateUser(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "Промените бяха записани успешно.";
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Възникна грешка!";
            }

            return View(model);

        }
        public async Task<IActionResult> CreateRole()
        {
            await roleManager.CreateAsync(new IdentityRole()
            {
                Name = "HouseKeeper"
            });

            return Ok();
        }
    }
}
