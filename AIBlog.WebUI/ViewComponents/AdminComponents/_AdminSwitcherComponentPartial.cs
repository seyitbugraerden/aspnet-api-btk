using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebUI.ViewComponents.AdminComponents
{
    public class _AdminSwitcherComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
