using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebUI.Controllers
{
    public sealed class AdminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
