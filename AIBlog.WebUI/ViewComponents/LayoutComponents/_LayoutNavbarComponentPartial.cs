using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIBlog.WebUI.Dtos.ArticleDtos;
using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutNavbarComponentPartial:ViewComponent
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public _LayoutNavbarComponentPartial(
            IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _httpClientFactory.CreateClient();

            using var response = await client.GetAsync(
                "http://localhost:5159/api/Categories");

            if (response.IsSuccessStatusCode)
            {
                var categories = await response.Content
                    .ReadFromJsonAsync<List<ResultHomeCategoriesDto>>();

                return View(categories ?? new List<ResultHomeCategoriesDto>());
            }

            return View(new List<ResultHomeCategoriesDto>());
        }
    }
}