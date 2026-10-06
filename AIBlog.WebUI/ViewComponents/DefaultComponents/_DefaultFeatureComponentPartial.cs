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

            using var response = await client.GetAsync(
                "http://localhost:5159/api/Articles/GetLastTechnologyArticles");

            if (!response.IsSuccessStatusCode)
                return View(new JsonObject());

            var article = await response.Content
                .ReadFromJsonAsync<JsonObject>();

            return View(article ?? new JsonObject());
        }
    }
}