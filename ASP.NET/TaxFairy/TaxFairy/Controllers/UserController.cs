using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using TaxFairy.Controllers;
using TaxFairy.Core.Contracts;
using TaxFairy.Infrastructure.Data.Identity;

namespace Warehouse.Controllers
{
    public class UserController : BaseController
    {
        private readonly RoleManager<IdentityRole> roleManager;

        private readonly UserManager<ApplicationUser> userManager;

        private readonly IUserService service;

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


        //Method to create first role:

        public async Task<IActionResult> CreateRole()
        {
        //    await roleManager.CreateAsync(new IdentityRole()
        //    {
        //        Name = "Administrator"

        //    });
           return Ok();

        }
    }
}