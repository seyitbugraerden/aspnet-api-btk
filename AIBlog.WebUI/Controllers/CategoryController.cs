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
        try
        {
            var client = _httpClientFactory.CreateClient();
            using var response = await client.GetAsync(ApiUrl);
            if (response.IsSuccessStatusCode)
            {
                return View(await response.Content.ReadFromJsonAsync<List<ResulCategoryDto>>() ?? new());
            }
        }
        catch (HttpRequestException) { }
        catch (TaskCanceledException) { }

        ViewBag.ErrorMessage = "Kategoriler yüklenemedi. Lütfen tekrar deneyin.";
        return View(new List<ResulCategoryDto>());
    }

    [HttpGet]
    public IActionResult CreateCategory() => View(new CreateCategoryDto());

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateCategory(CreateCategoryDto model)
    {
        if (!ModelState.IsValid) return View(model);

        try
        {
            var client = _httpClientFactory.CreateClient();
            using var response = await client.PostAsJsonAsync(ApiUrl, new { CategoryName = model.CategoryName.Trim() });
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Kategori oluşturuldu.";
                return RedirectToAction(nameof(CategoryList));
            }
        }
        catch (HttpRequestException) { }
        catch (TaskCanceledException) { }

        ModelState.AddModelError(string.Empty, "Kategori oluşturulamadı. Lütfen tekrar deneyin.");
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> UpdateCategory(int id)
    {
        if (id <= 0) return BadRequest();
        try
        {
            var client = _httpClientFactory.CreateClient();
            using var response = await client.GetAsync($"{ApiUrl}/{id}");
            if (response.StatusCode == HttpStatusCode.NotFound) return NotFound();
            if (response.IsSuccessStatusCode)
            {
                var model = await response.Content.ReadFromJsonAsync<UpdateCategoryDto>();
                if (model is not null) return View(model);
            }
        }
        catch (HttpRequestException) { }
        catch (TaskCanceledException) { }

        TempData["ErrorMessage"] = "Kategori yüklenemedi. Lütfen tekrar deneyin.";
        return RedirectToAction(nameof(CategoryList));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateCategory(UpdateCategoryDto model)
    {
        if (model.CategoryId <= 0) return BadRequest();
        if (!ModelState.IsValid) return View(model);

        try
        {
            var client = _httpClientFactory.CreateClient();
            using var response = await client.PutAsJsonAsync($"{ApiUrl}/{model.CategoryId}", new { CategoryName = model.CategoryName.Trim() });
            if (response.StatusCode == HttpStatusCode.NotFound) return NotFound();
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Kategori güncellendi.";
                return RedirectToAction(nameof(CategoryList));
            }
        }
        catch (HttpRequestException) { }
        catch (TaskCanceledException) { }

        ModelState.AddModelError(string.Empty, "Kategori güncellenemedi. Lütfen tekrar deneyin.");
        return View(model);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteCategory(int id)
    {
        if (id <= 0) return BadRequest();
        try
        {
            var client = _httpClientFactory.CreateClient();
            using var response = await client.DeleteAsync($"{ApiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Kategori silindi.";
                return RedirectToAction(nameof(CategoryList));
            }
        }
        catch (HttpRequestException) { }
        catch (TaskCanceledException) { }

        TempData["ErrorMessage"] = "Kategori silinemedi. Kategoriye bağlı yazılar olabilir veya API erişilemiyor olabilir.";
        return RedirectToAction(nameof(CategoryList));
    }
}
