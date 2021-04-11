using Microsoft.AspNetCore.Mvc;

namespace LibraryApi.Controllers
{
    public class PublishersController : Controller
    {
        // GET
        public IActionResult Index()
        {
            return View();
        }
    }
}