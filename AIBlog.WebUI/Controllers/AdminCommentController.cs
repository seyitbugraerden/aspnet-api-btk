using System.Net;
using AIBlog.WebUI.Dtos.CommentDtos;
using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebUI.Controllers;

public class AdminCommentController(IHttpClientFactory httpClientFactory) : Controller
{
    private const string ApiUrl = "http://localhost:5159/api/Comments";
    public IActionResult Index() => RedirectToAction(nameof(CommentList));

    [HttpGet]
    public async Task<IActionResult> CommentList(int? articleId, bool? confirmed)
    {
        if (articleId <= 0) return BadRequest();
        ViewBag.ArticleId = articleId;
        ViewBag.Confirmed = confirmed;
        try
        {
            var client = httpClientFactory.CreateClient();
            using var response = await client.GetAsync(articleId.HasValue ? $"{ApiUrl}?articleId={articleId}" : ApiUrl);
            if (response.IsSuccessStatusCode)
            {
                var comments = await response.Content.ReadFromJsonAsync<List<ResultCommentDto>>() ?? new();
                return View(comments.Where(c => !confirmed.HasValue || c.IsConfirmed == confirmed.Value).ToList());
            }
        }
        catch (HttpRequestException) { }
        catch (TaskCanceledException) { }
        ViewBag.ErrorMessage = "Yorumlar yüklenemedi. API bağlantısını kontrol edip tekrar deneyin.";
        return View(new List<ResultCommentDto>());
    }

    [HttpGet]
    public async Task<IActionResult> UpdateComment(int id)
    {
        try
        {
            var comment = await ReadCommentAsync(id);
            if (comment == null) return NotFound();
            ViewBag.Comment = comment;
            return View(new UpdateCommentDto { CommentId = id, ArticleId = comment.ArticleId,
                CommentDetail = comment.CommentDetail, IsConfirmed = comment.IsConfirmed });
        }
        catch (HttpRequestException) { }
        catch (TaskCanceledException) { }
        TempData["ErrorMessage"] = "Yorum yüklenemedi.";
        return RedirectToAction(nameof(CommentList));
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> UpdateComment(UpdateCommentDto model)
    {
        try
        {
            var comment = await ReadCommentAsync(model.CommentId);
            if (comment == null) return NotFound();
            ViewBag.Comment = comment;
            if (!ModelState.IsValid) return View(model);
            using var response = await WriteCommentAsync(comment, model.CommentDetail.Trim(), model.IsConfirmed);
            if (response.IsSuccessStatusCode)
            {
                TempData["SuccessMessage"] = "Yorum güncellendi.";
                return RedirectToAction(nameof(CommentList), new { articleId = comment.ArticleId });
            }
        }
        catch (HttpRequestException) { }
        catch (TaskCanceledException) { }
        ModelState.AddModelError(string.Empty, "Yorum güncellenemedi. Lütfen tekrar deneyin.");
        return View(model);
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> SetConfirmation(int id, bool isConfirmed, int? articleId, bool? confirmed)
    {
        try
        {
            var comment = await ReadCommentAsync(id);
            if (comment == null) TempData["ErrorMessage"] = "Yorum bulunamadı; daha önce silinmiş olabilir.";
            else
            {
                using var response = await WriteCommentAsync(comment, comment.CommentDetail, isConfirmed);
                TempData[response.IsSuccessStatusCode ? "SuccessMessage" : "ErrorMessage"] = response.IsSuccessStatusCode
                    ? (isConfirmed ? "Yorum onaylandı ve yayına alındı." : "Yorum yayından kaldırıldı; onay bekliyor.") : "Yorumun durumu değiştirilemedi.";
            }
        }
        catch (HttpRequestException) { TempData["ErrorMessage"] = "API bağlantısı kurulamadı."; }
        catch (TaskCanceledException) { TempData["ErrorMessage"] = "İşlem zaman aşımına uğradı. Listeyi yenileyerek durumu kontrol edin."; }
        return RedirectToAction(nameof(CommentList), new { articleId, confirmed });
    }

    [HttpPost, ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteComment(int id, int? articleId, bool? confirmed)
    {
        try
        {
            using var response = await httpClientFactory.CreateClient().DeleteAsync($"{ApiUrl}/{id}");
            TempData[response.IsSuccessStatusCode ? "SuccessMessage" : "ErrorMessage"] = response.IsSuccessStatusCode
                ? "Yorum silindi." : response.StatusCode == HttpStatusCode.NotFound ? "Yorum zaten silinmiş." : "Yorum silinemedi.";
        }
        catch (HttpRequestException) { TempData["ErrorMessage"] = "API bağlantısı kurulamadı."; }
        catch (TaskCanceledException) { TempData["ErrorMessage"] = "İşlem zaman aşımına uğradı. Listeyi yenileyerek durumu kontrol edin."; }
        return RedirectToAction(nameof(CommentList), new { articleId, confirmed });
    }

    private async Task<ResultCommentDto?> ReadCommentAsync(int id)
    {
        using var response = await httpClientFactory.CreateClient().GetAsync($"{ApiUrl}/{id}");
        if (response.StatusCode == HttpStatusCode.NotFound) return null;
        response.EnsureSuccessStatusCode();
        return await response.Content.ReadFromJsonAsync<ResultCommentDto>();
    }

    private Task<HttpResponseMessage> WriteCommentAsync(ResultCommentDto comment, string detail, bool confirmed) =>
        httpClientFactory.CreateClient().PutAsJsonAsync($"{ApiUrl}/{comment.CommentId}", new
        {
            comment.CommentId, comment.ArticleId, comment.AppUserId,
            CommentDetail = detail, IsConfirmed = confirmed
        });
}
