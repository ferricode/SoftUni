using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaxFairy.Core.Constants;
using TaxFairy.Core.Contracts;
using TaxFairy.Core.ViewModels;

namespace TaxFairy.Controllers
{
    public class VendorController : BaseController
    {
        private readonly IVendorService service;

        public VendorController(IVendorService _service)
        {
            service = _service;
        }

        // GET: VendorController
        public async Task<IActionResult> ManageVendors()
        {
            var vendors = await service.GetVendorList();
            return View(vendors);
        }

        // GET: VendorController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: VendorController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: VendorController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(VendorCreateViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await service.CreateVendor(model))
            {

                return Redirect("/Vendor/ManageVendors");
            }
            else
            {
                ViewData[MessageConstant.ErrorMessage] = "Възникна грешка!";
                return View(model);

            }

        }



        // GET: VendorController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: VendorController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: VendorController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: VendorController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
