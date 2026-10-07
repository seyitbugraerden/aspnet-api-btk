using System.Net.Http.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultFeatureComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultFeatureComponentPartial(
            IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            var technologyTask = GetArticleAsync(client, "GetLastTechnologyArticles");
            var foodTask = GetArticleAsync(client, "GetLastFoodArticles");
            var sportTask = GetArticleAsync(client, "GetLastSportArticles");

            await Task.WhenAll(technologyTask, foodTask, sportTask);

            ViewBag.TechnologyArticle = await technologyTask;
            ViewBag.FoodArticle = await foodTask;
            ViewBag.SportArticle = await sportTask;

            return View();
        }

        private static async Task<JsonObject> GetArticleAsync(HttpClient client, string endpoint)
        {
            using var response = await client.GetAsync(
                $"http://localhost:5159/api/Articles/{endpoint}");

            if (!response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NoContent)
                return new JsonObject();

            var article = await response.Content
                .ReadFromJsonAsync<JsonObject>();

            return article ?? new JsonObject();
        }
    }
}
