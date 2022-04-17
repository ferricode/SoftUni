﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxFairy.Core.Constants;
using TaxFairy.Core.Contracts;

namespace TaxFairy.Areas.Admin.Controllers
{
    [Authorize(Roles = UserConstants.Roles.Administrator)]
    [Area("Admin")]
    public class PrivacyController : Controller
    {
        private IPrivacyService service;
        public PrivacyController(IPrivacyService _service)
        {
            service = _service;
        }
        [HttpGet]
        public IActionResult Index()
        {

            var privacy = service.GetPrivacy();
            return View(privacy);


        }

    }
}
