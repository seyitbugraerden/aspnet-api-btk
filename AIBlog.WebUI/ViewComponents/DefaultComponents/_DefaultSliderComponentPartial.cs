using System.Net.Http.Json;
using AIBlog.WebUI.Dtos.ArticleDtos;
using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultSliderComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultSliderComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            using var responseMessage = await client.GetAsync("http://localhost:5159/api/Articles/GetArticlesFeatureSliderByTrue");

            if (responseMessage.IsSuccessStatusCode)
            {
                var articles = await responseMessage.Content
                    .ReadFromJsonAsync<List<ResultHomeArticleDto>>();

                return View(articles ?? new List<ResultHomeArticleDto>());
            }

            return View(new List<ResultHomeArticleDto>());
        }
    }
}
