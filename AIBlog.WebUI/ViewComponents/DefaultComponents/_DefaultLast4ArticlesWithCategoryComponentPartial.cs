using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIBlog.WebUI.Dtos.ResultHomeLastArticle;
using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultLast4ArticlesWithCategoryComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke(List<ResultHomeLastArticle> articles)
        {
            return View(articles);
        }
    }
}
