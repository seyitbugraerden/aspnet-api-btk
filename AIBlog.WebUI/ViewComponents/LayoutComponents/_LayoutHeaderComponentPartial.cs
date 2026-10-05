using System.Net.Http.Json;
using AIBlog.WebUI.Dtos.ArticleDtos;
using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutHeaderComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _LayoutHeaderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            using var responseMessage = await client.GetAsync("http://localhost:5159/api/Articles");
            if (responseMessage.IsSuccessStatusCode)
            {
                var articles = await responseMessage.Content.ReadFromJsonAsync<List<ResultArticleDto>>();
                var latestArticles = (articles ?? new List<ResultArticleDto>())
                    .OrderByDescending(article => article.CreatedDate)
                    .ThenByDescending(article => article.ArticleId)
                    .Take(3)
                    .ToList();

                return View(latestArticles);
            }

            return View(new List<ResultArticleDto>());
        }
    }
}
