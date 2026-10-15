using AIBlog.WebUI.Dtos.ArticleDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using AIBlog.WebUI.Dtos.CategoryDtos;
using System.Net;

namespace AIBlog.WebUI.Controllers;

public class AdminArticleController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private const string ApiUrl = "http://localhost:5159/api/Articles";

    public AdminArticleController(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public IActionResult Index() => RedirectToAction(nameof(ArticleList));

    [HttpGet]
    public async Task<IActionResult> ArticleList()
    {
        var client = _httpClientFactory.CreateClient();
        using var response = await client.GetAsync(ApiUrl);
        if (response.IsSuccessStatusCode)
        {
            return View(await response.Content.ReadFromJsonAsync<List<ResultArticleDto>>() ?? new());
        }
        ViewBag.ErrorMessage = "Makaleler yüklenemedi. Lütfen tekrar deneyin.";
        return View(new List<ResultArticleDto>());
    }

    [HttpGet]
    public async Task<IActionResult> CreateArticle()
    {
        await LoadCategoriesAsync();
        return View(new CreateArticleDto());
    }

    [HttpPost]
    public async Task<IActionResult> CreateArticle(CreateArticleDto model)
    {
        if (!ModelState.IsValid)
        {
            await LoadCategoriesAsync();
            return View(model);
        }

        var client = _httpClientFactory.CreateClient();
        using var response = await client.PostAsJsonAsync(ApiUrl, model);
        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Makale oluşturuldu.";
            return RedirectToAction(nameof(ArticleList));
        }
        await LoadCategoriesAsync();
        ModelState.AddModelError(string.Empty, "Makale oluşturulamadı.");
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> UpdateArticle(int id)
    {
        var client = _httpClientFactory.CreateClient();
        using var response = await client.GetAsync($"{ApiUrl}/{id}");
        if (response.StatusCode == HttpStatusCode.NotFound) return NotFound();
        if (response.IsSuccessStatusCode)
        {
            var article = await response.Content.ReadFromJsonAsync<GetArticleByIdDto>();
            if (article is not null)
            {
                await LoadCategoriesAsync();
                return View(new UpdateArticleDto
                {
                    ArticleId = article.ArticleId,
                    Title = article.Title,
                    CoverImageUrl = article.CoverImageUrl,
                    MainImageUrl = article.MainImageUrl,
                    Content = article.Content,
                    CreatedDate = article.CreatedDate,
                    CategoryId = article.CategoryId
                });
            }
        }
        TempData["ErrorMessage"] = "Makale yüklenemedi.";
        return RedirectToAction(nameof(ArticleList));
    }

    [HttpPost]
    public async Task<IActionResult> UpdateArticle(UpdateArticleDto model)
    {
        if (!ModelState.IsValid)
        {
            await LoadCategoriesAsync();
            return View(model);
        }

        var client = _httpClientFactory.CreateClient();
        using var response = await client.PutAsJsonAsync(ApiUrl, model);
        if (response.StatusCode == HttpStatusCode.NotFound) return NotFound();
        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Makale güncellendi.";
            return RedirectToAction(nameof(ArticleList));
        }
        await LoadCategoriesAsync();
        ModelState.AddModelError(string.Empty, "Makale güncellenemedi.");
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteArticle(int id)
    {
        var client = _httpClientFactory.CreateClient();
        using var response = await client.DeleteAsync($"{ApiUrl}/{id}");
        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Makale silindi.";
        }
        else
        {
            TempData["ErrorMessage"] = "Makale silinemedi.";
        }
        return RedirectToAction(nameof(ArticleList));
    }

    private async Task LoadCategoriesAsync()
    {
        var client = _httpClientFactory.CreateClient();
        using var response = await client.GetAsync("http://localhost:5159/api/Categories");
        var categories = response.IsSuccessStatusCode
            ? await response.Content.ReadFromJsonAsync<List<ResulCategoryDto>>() ?? new()
            : new List<ResulCategoryDto>();
        ViewBag.Categories = new SelectList(categories, "CategoryId", "CategoryName");
        if (!response.IsSuccessStatusCode)
        {
            ModelState.AddModelError(string.Empty, "Kategoriler yüklenemedi. Lütfen tekrar deneyin.");
        }
    }

}
