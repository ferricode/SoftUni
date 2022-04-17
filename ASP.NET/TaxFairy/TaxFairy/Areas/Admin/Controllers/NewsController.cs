using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TaxFairy.Core.Constants;
using TaxFairy.Core.Contracts;

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
    }
}
