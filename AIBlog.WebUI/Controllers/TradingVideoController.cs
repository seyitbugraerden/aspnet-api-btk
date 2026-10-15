using AIBlog.WebUI.Dtos.TradingVideoDtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace AIBlog.WebUI.Controllers;

public class TradingVideoController : Controller
{
    private readonly IHttpClientFactory _httpClientFactory;
    private const string ApiUrl = "http://localhost:5159/api/TradingVideos";

    public TradingVideoController(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

    public IActionResult Index() => RedirectToAction(nameof(TradingVideoList));

    [HttpGet]
    public async Task<IActionResult> TradingVideoList()
    {
        var client = _httpClientFactory.CreateClient();
        using var response = await client.GetAsync(ApiUrl);
        if (response.IsSuccessStatusCode)
            return View(await response.Content.ReadFromJsonAsync<List<ResultTradingVideoDto>>() ?? new());
        ViewBag.ErrorMessage = "Videolar yüklenemedi. Lütfen tekrar deneyin.";
        return View(new List<ResultTradingVideoDto>());
    }

    [HttpGet]
    public IActionResult CreateTradingVideo() => View(new CreateTradingVideoDto());

    [HttpPost]
    public async Task<IActionResult> CreateTradingVideo(CreateTradingVideoDto model)
    {
        if (!ModelState.IsValid) return View(model);
        var client = _httpClientFactory.CreateClient();
        using var response = await client.PostAsJsonAsync(ApiUrl, model);
        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Video oluşturuldu.";
            return RedirectToAction(nameof(TradingVideoList));
        }
        ModelState.AddModelError(string.Empty, "Video oluşturulamadı. Alanları kontrol edip tekrar deneyin.");
        return View(model);
    }

    [HttpGet]
    public async Task<IActionResult> UpdateTradingVideo(int id)
    {
        if (id <= 0) return BadRequest();
        var client = _httpClientFactory.CreateClient();
        using var response = await client.GetAsync($"{ApiUrl}/{id}");
        if (response.StatusCode == HttpStatusCode.NotFound) return NotFound();
        if (response.IsSuccessStatusCode)
        {
            var video = await response.Content.ReadFromJsonAsync<ResultTradingVideoDto>();
            if (video != null)
                return View(new UpdateTradingVideoDto
                {
                    TradingVideoId = video.TradingVideoId, Title = video.Title,
                    ThumbnailImageUrl = video.ThumbnailImageUrl, EmbedVideoUrl = video.EmbedVideoUrl
                });
        }
        TempData["ErrorMessage"] = "Video yüklenemedi.";
        return RedirectToAction(nameof(TradingVideoList));
    }

    [HttpPost]
    public async Task<IActionResult> UpdateTradingVideo(UpdateTradingVideoDto model)
    {
        if (model.TradingVideoId <= 0) return BadRequest();
        if (!ModelState.IsValid) return View(model);
        var client = _httpClientFactory.CreateClient();
        using var response = await client.PutAsJsonAsync($"{ApiUrl}/{model.TradingVideoId}", model);
        if (response.StatusCode == HttpStatusCode.NotFound) return NotFound();
        if (response.IsSuccessStatusCode)
        {
            TempData["SuccessMessage"] = "Video güncellendi.";
            return RedirectToAction(nameof(TradingVideoList));
        }
        ModelState.AddModelError(string.Empty, "Video güncellenemedi. Alanları kontrol edip tekrar deneyin.");
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteTradingVideo(int id)
    {
        if (id <= 0) return BadRequest();
        var client = _httpClientFactory.CreateClient();
        using var response = await client.DeleteAsync($"{ApiUrl}/{id}");
        TempData[response.IsSuccessStatusCode ? "SuccessMessage" : "ErrorMessage"] = response.IsSuccessStatusCode
            ? "Video silindi." : "Video silinemedi.";
        return RedirectToAction(nameof(TradingVideoList));
    }
}
