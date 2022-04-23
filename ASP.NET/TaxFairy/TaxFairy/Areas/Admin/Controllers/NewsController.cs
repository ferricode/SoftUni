using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TaxFairy.Core.Constants;
using TaxFairy.Core.Contracts;
using TaxFairy.Core.ViewModels;
using TaxFairy.Models;

namespace TaxFairy.Areas.Admin.Controllers
{
    [Authorize(Roles = UserConstants.Roles.Administrator)]
    [Area("Admin")]
    public class NewsController : Controller
    {
        private INewsService service;
        public NewsController(INewsService _service)
        {
            service = _service;
        }
        public async Task<IActionResult> ManageNews()
        {
            var news = await service.GetNewsList();
            return View(news);
        }
        public async Task<IActionResult> Edit(string id)
        {
            var model = await service.GetNewsToEdit(id);

            return View(model);

        }
        public async Task<IActionResult> Create()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewsCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await service.CreateNews(model))
            {
         
                return Redirect("/Admin/News/ManageNews");
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Възникна грешка!";
                return View(model);

            }



        }
        [HttpPost]
        public async Task<IActionResult> Edit(NewsViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await service.EditNews(model))
            {
                ViewData[MessageConstant.SuccessMessage] = "Промените бяха записани успешно.";
               
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Възникна грешка!";
          

            }

            return View(model);

        }
    }
}
