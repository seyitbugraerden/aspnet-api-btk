using System.Net.Http.Json;
using AIBlog.WebUI.Dtos.ArticleDtos;
using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebUI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ArticleController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public IActionResult ArticleDetail()
        {
            return View();
        }
        public async Task<IActionResult> ArticleList()
        {

            var client = _httpClientFactory.CreateClient();
            using var responseMessage = await client.GetAsync("http://localhost:5159/api/Articles");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultArticleDto>>();
                return View(values ?? new List<ResultArticleDto>());
            }
            return View(new List<ResultArticleDto>());
        }
        public IActionResult ArticleListByCategory()
        {
            return View();
        }
    }
}
