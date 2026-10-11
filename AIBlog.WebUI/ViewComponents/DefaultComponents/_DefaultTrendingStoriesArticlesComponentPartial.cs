using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIBlog.WebUI.Dtos.ArticleDtos;
using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultTrendingStoriesArticlesComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;
        public _DefaultTrendingStoriesArticlesComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("http://localhost:5159/api/Articles/GetTrendingArticles");
            if (responseMessage.IsSuccessStatusCode)
            {
                var articles = await responseMessage.Content.ReadFromJsonAsync<List<ResultArticleDto>>();
                return View(articles ?? new List<ResultArticleDto>());
            }
            return View(new List<ResultArticleDto>());
        }
    }
}