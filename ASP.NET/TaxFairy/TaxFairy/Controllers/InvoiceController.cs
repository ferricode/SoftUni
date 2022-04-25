﻿using Microsoft.AspNetCore.Mvc;
using TaxFairy.Core.Contracts;
using TaxFairy.Infrastructure.Data;

namespace TaxFairy.Controllers
{
    public class InvoiceController : BaseController
    {
    
        private readonly ApplicationDbContext context;
        private readonly IInvoiceService service;
        public InvoiceController(ApplicationDbContext _context,
            IInvoiceService _service)
        {
            service = _service;
            context = _context;
        }
        // GET: InvoiceController
        public async Task<IActionResult> Index()
        {
            //InvoiceListViewModel

            var model = await service.GetInvoices();

          Request.Cookies.TryGetValue("vendorName", out string? vendor);

            TempData["name"] = vendor;
        
            return View(model);
        }

        // GET: InvoiceController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: InvoiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
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

        // GET: InvoiceController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: InvoiceController/Edit/5
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

        // GET: InvoiceController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: InvoiceController/Delete/5
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
