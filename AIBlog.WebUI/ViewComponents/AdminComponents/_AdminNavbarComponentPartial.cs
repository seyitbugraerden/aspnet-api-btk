using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebUI.ViewComponents.AdminComponents
{
    public class _AdminNavbarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
