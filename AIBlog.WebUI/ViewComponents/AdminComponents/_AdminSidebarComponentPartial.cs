using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebUI.ViewComponents.AdminComponents
{
    public class _AdminSidebarComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
