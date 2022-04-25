using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
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


        public async Task<IActionResult> Details(string id)
        {
            var vendor = await service.GetVendorToEdit(id);

            _ = Request.Cookies["vendorName"];
            string vendorName = vendor.Name;

            Response.Cookies.Append("vendorName", vendorName,
                new CookieOptions
                {
                    Expires = DateTime.UtcNow.AddMonths(2),
                    SameSite = SameSiteMode.Strict
                });

            return View(vendor);
        }
        // GET: VendorController
        public async Task<IActionResult> ManageVendors()
        {
            var vendors = await service.GetVendorList();
            return View(vendors);
        }


        // GET: VendorController/Create
        public IActionResult Create()
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


        public async Task<IActionResult> Edit(string id)
        {
            var model = await service.GetVendorToEdit(id);
            return View(model);

        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(VendorEditViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (await service.EditVendor(model))
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
