using Microsoft.AspNetCore.Mvc;
using TaxFairy.Core.Constants;
using TaxFairy.Core.Contracts;
using TaxFairy.Core.ViewModels;

namespace TaxFairy.Controllers
{
    public class ContragentController : BaseController
    {
        private readonly IContragentService service;

        public ContragentController(IContragentService _service)
        {
            service = _service;
        }
        public IActionResult Index()
        {
            return View();
        }
        public async Task<IActionResult> ManageContragents()
        {
            var contragents = await service.GetContragentList();
            return View(contragents);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ContragentCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await service.CreateContragent(model))
            {

                return Redirect("/Contragent/ManageContragents");
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Възникна грешка!";
                return View(model);

            }

        }
        public async Task<IActionResult> Details(string id)
        {
            var client = await service.GetContragentToEdit(id);

          
            return View(client);
        }

        public async Task<IActionResult> Edit(string id)
        {
            var model = await service.GetContragentToEdit(id);
            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(ContragentEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await service.EditContragent(model))
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
