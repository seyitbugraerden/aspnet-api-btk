using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIBlog.WebUI.Dtos.ArticleDtos;
using AIBlog.WebUI.Dtos.ResultHomeLastArticle;
using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultLatestPostsComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultLatestPostsComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5159/api/Articles/GetHomeLastArticles");
            if (responseMessage.IsSuccessStatusCode)
            {
                var articles = await responseMessage.Content.ReadFromJsonAsync<List<ResultHomeLastArticle>>();
                return View(articles ?? new List<ResultHomeLastArticle>());
            }
            return View(new List<ResultHomeLastArticle>());
        }
    }
}