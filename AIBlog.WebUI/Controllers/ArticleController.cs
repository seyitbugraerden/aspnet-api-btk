using System.Net.Http.Json;
using System.Security.Claims;
using AIBlog.WebUI.Dtos.CommentDtos;
using AIBlog.WebUI.Dtos.ArticleDtos;
using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebUI.Controllers
{
    public class ArticleController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ArticleController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [HttpGet]
        public async Task<IActionResult> ArticleDetail(int id)
        {
            if (id <= 0) return BadRequest();
            var client = _httpClientFactory.CreateClient();
            using var response = await client.GetAsync($"http://localhost:5159/api/Articles/{id}");
            if (response.StatusCode == System.Net.HttpStatusCode.NotFound) return NotFound();
            if (!response.IsSuccessStatusCode) return StatusCode(503, "Makale yüklenemedi.");
            var article = await response.Content.ReadFromJsonAsync<GetArticleByIdDto>();
            if (article == null) return NotFound();
            return View(article);
        }

        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto model)
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (User.Identity?.IsAuthenticated != true || string.IsNullOrWhiteSpace(userId)) return Unauthorized();
            if (model.ArticleId <= 0) return BadRequest();
            if (!ModelState.IsValid)
            {
                TempData["CommentError"] = "Yorum metni zorunludur ve en fazla 4000 karakter olabilir.";
                return RedirectToAction(nameof(ArticleDetail), new { id = model.ArticleId });
            }
            var client = _httpClientFactory.CreateClient();
            using var response = await client.PostAsJsonAsync("http://localhost:5159/api/Comments", new
            {
                model.ArticleId, model.CommentDetail, AppUserId = userId
            });
            TempData[response.IsSuccessStatusCode ? "CommentSuccess" : "CommentError"] = response.IsSuccessStatusCode
                ? "Yorumunuz alındı. Onaylandıktan sonra yayınlanacak." : "Yorum gönderilemedi. Lütfen tekrar deneyin.";
            return RedirectToAction(nameof(ArticleDetail), new { id = model.ArticleId });
        }
        public async Task<IActionResult> ArticleList()
        {

            var client = _httpClientFactory.CreateClient();
            using var responseMessage = await client.GetAsync("http://localhost:5159/api/Articles");
            if (responseMessage.IsSuccessStatusCode)
            {
                var values = await responseMessage.Content.ReadFromJsonAsync<List<ResultArticleDto>>();
                return View(values ?? new List<ResultArticleDto>());
            }
            return View(new List<ResultArticleDto>());
        }
        public IActionResult ArticleListByCategory()
        {
            return View();
        }
    }
}
