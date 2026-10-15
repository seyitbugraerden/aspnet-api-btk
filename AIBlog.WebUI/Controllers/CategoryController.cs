using AIBlog.WebUI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AIBlog.WebUI.Controllers;

public class CategoryController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private const string ApiUrl = "http://localhost:5159/api/Categories";

    public CategoryController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    [HttpGet]
    public async Task<IActionResult> CategoryList()
    {
        var client = _httpClientFactory.CreateClient();
        using var response = await client.GetAsync(ApiUrl);
        if (response.IsSuccessStatusCode)
        {
            return View(await response.Content.ReadFromJsonAsync<List<ResulCategoryDto>>() ?? new());
        }
        return View(new List<ResulCategoryDto>());
    }

    [HttpGet]
    public IActionResult CreateCategory() => View(new CreateCategoryDto());

    [HttpPost]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto model)
    {
        if (!ModelState.IsValid) return View(model);

        var client = _httpClientFactory.CreateClient();
        using var response = await client.PostAsJsonAsync(ApiUrl, new { CategoryName = model.CategoryName.Trim() });
        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Kategori oluşturuldu.";
            return RedirectToAction(nameof(CategoryList));
        }

        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> UpdateCategory(int id)
    {
        var client = _httpClientFactory.CreateClient();
        using var response = await client.GetAsync($"{ApiUrl}/{id}");
        if (response.StatusCode == HttpStatusCode.NotFound) return NotFound();
        if (response.IsSuccessStatusCode)
        {
            var model = await response.Content.ReadFromJsonAsync<UpdateCategoryDto>();
            if (model is not null) return View(model);
        }

        return RedirectToAction(nameof(CategoryList));
    }

    [HttpPost]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto model)
    {
        var client = _httpClientFactory.CreateClient();
        using var response = await client.PutAsJsonAsync($"{ApiUrl}/{model.CategoryId}", new { CategoryName = model.CategoryName.Trim() });
        if (response.StatusCode == HttpStatusCode.NotFound) return NotFound();
        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Kategori güncellendi.";
            return RedirectToAction(nameof(CategoryList));
        }
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        var client = _httpClientFactory.CreateClient();
        using var response = await client.DeleteAsync($"{ApiUrl}/{id}");
        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Kategori silindi.";
            return RedirectToAction(nameof(CategoryList));
        }
        return RedirectToAction(nameof(CategoryList));
    }
}
