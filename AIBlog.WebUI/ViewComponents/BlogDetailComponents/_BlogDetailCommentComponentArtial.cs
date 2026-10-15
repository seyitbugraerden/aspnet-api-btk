using AIBlog.WebUI.Dtos.CommentDtos;
using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebUI.ViewComponents.BlogDetailComponents;

public class _BlogDetailCommentComponentArtial : ViewComponent
{
    private readonly IHttpClientFactory _httpClientFactory;
    public _BlogDetailCommentComponentArtial(IHttpClientFactory httpClientFactory) => _httpClientFactory = httpClientFactory;

    public async Task<IViewComponentResult> InvokeAsync(int articleId = 0)
    {
        if (articleId <= 0) return View(new List<ResultCommentDto>());
        var client = _httpClientFactory.CreateClient();
        using var response = await client.GetAsync($"http://localhost:5159/api/Comments?articleId={articleId}&confirmedOnly=true");
        if (response.IsSuccessStatusCode)
            return View(await response.Content.ReadFromJsonAsync<List<ResultCommentDto>>() ?? new());
        ViewBag.CommentError = "Yorumlar şu anda yüklenemedi.";
        return View(new List<ResultCommentDto>());
    }
}
