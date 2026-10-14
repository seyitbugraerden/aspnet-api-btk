using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebUI.ViewComponents.AdminComponents
{
    public class _AdminHeadComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
