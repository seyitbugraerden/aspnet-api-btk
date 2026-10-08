using System.Net.Http.Json;
using AIBlog.WebUI.Dtos.ArticleDtos;
using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultGetCategoriesWithLastArticleComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _DefaultGetCategoriesWithLastArticleComponentPartial(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();
            using var response = await client.GetAsync(
                "http://localhost:5159/api/Articles/GetLastArticlesOfDifferemtCategories");

            if (!response.IsSuccessStatusCode || response.StatusCode == System.Net.HttpStatusCode.NoContent)
            {
                return View(new List<ResultCategoryWithLastArticleDto>());
            }

            var articles = await response.Content.ReadFromJsonAsync<List<ResultHomeArticleDto>>();
            var values = articles?.Select(article => new ResultCategoryWithLastArticleDto
            {
                ArticleId = article.ArticleId,
                CategoryName = article.CategoryName,
                LastArticleTitle = article.Title,
                LastArticleImage = article.CoverImageUrl,
                LastArticleDate = article.CreatedDate
            }).ToList() ?? new List<ResultCategoryWithLastArticleDto>();

            return View(values);
        }
    }
}
