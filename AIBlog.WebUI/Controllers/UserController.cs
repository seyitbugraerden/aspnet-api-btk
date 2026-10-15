using AIBlog.WebUI.Dtos.UserDtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Text.Json;

namespace AIBlog.WebUI.Controllers;

public class UserController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private const string ApiUrl = "http://localhost:5159/api/Users";

    public UserController(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

    public IActionResult Index() => RedirectToAction(nameof(UserList));

    [HttpGet]
    public async Task<IActionResult> UserList()
    {
        var client = _httpClientFactory.CreateClient();
        using var response = await client.GetAsync(ApiUrl);
        if (response.IsSuccessStatusCode)
            return View(await response.Content.ReadFromJsonAsync<List<ResultUserDto>>() ?? new());
        ViewBag.ErrorMessage = "Kullanıcılar yüklenemedi.";
        return View(new List<ResultUserDto>());
    }

    [HttpGet]
    public IActionResult CreateUser() => View(new CreateUserDto());

    [HttpPost]
    public async Task<IActionResult> CreateUser(CreateUserDto model)
    {
        if (!ModelState.IsValid) return View(model);
        var client = _httpClientFactory.CreateClient();
        using var response = await client.PostAsJsonAsync(ApiUrl, model);
        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Kullanıcı oluşturuldu.";
            return RedirectToAction(nameof(UserList));
        }
        await AddApiErrorsAsync(response);
        model.Password = string.Empty;
        ModelState.Remove(nameof(model.Password));
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> UpdateUser(string id)
    {
        var client = _httpClientFactory.CreateClient();
        using var response = await client.GetAsync($"{ApiUrl}/{Uri.EscapeDataString(id)}");
        if (response.StatusCode == HttpStatusCode.NotFound) return NotFound();
        if (response.IsSuccessStatusCode)
        {
            var model = await response.Content.ReadFromJsonAsync<UpdateUserDto>();
            if (model != null) return View(model);
        }
        TempData["ErrorMessage"] = "Kullanıcı yüklenemedi.";
        return RedirectToAction(nameof(UserList));
    }

    [HttpPost]
    public async Task<IActionResult> UpdateUser(UpdateUserDto model)
    {
        if (!ModelState.IsValid) return View(model);
        var client = _httpClientFactory.CreateClient();
        using var response = await client.PutAsJsonAsync($"{ApiUrl}/{Uri.EscapeDataString(model.Id)}", model);
        if (response.StatusCode == HttpStatusCode.NotFound) return NotFound();
        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Kullanıcı güncellendi.";
            return RedirectToAction(nameof(UserList));
        }
        await AddApiErrorsAsync(response);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteUser(string id)
    {
        var client = _httpClientFactory.CreateClient();
        using var response = await client.DeleteAsync($"{ApiUrl}/{Uri.EscapeDataString(id)}");
        TempData[response.IsSuccessStatusCode ? "SuccessMessage" : "ErrorMessage"] = response.IsSuccessStatusCode
            ? "Kullanıcı silindi. Makaleleri korundu." : "Kullanıcı silinemedi.";
        return RedirectToAction(nameof(UserList));
    }

    private async Task AddApiErrorsAsync(HttpResponseMessage response)
    {
        if (response.StatusCode == HttpStatusCode.BadRequest)
        {
            var data = await response.Content.ReadFromJsonAsync<JsonElement>();
            if (data.ValueKind == JsonValueKind.Array)
            {
                foreach (var error in data.EnumerateArray())
                    ModelState.AddModelError(string.Empty, error.GetString() ?? "İşlem başarısız.");
                return;
            }
            if (data.ValueKind == JsonValueKind.Object && data.TryGetProperty("errors", out var errors))
            {
                foreach (var field in errors.EnumerateObject())
                    foreach (var error in field.Value.EnumerateArray())
                        ModelState.AddModelError(string.Empty, error.GetString() ?? "Geçersiz alan.");
                return;
            }
        }
        ModelState.AddModelError(string.Empty, "İşlem tamamlanamadı. Lütfen tekrar deneyin.");
    }
}
