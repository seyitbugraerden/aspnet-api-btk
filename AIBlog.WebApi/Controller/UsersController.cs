using AIBlog.WebApi.Entities;
using Microsoft.EntityFrameworkCore;
using AIBlog.WebApi.Dtos.UserDtos;
using AIBlog.WebApi.Dtos.ArticleDtos;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebApi.Controller
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;
        public UsersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            var values = await _userManager.Users
                .AsNoTracking()
                .Select(user => new ResultUserDto
                {
                    Id = user.Id,
                    Name = user.Name,
                    Surname = user.Surname,
                    ImageUrl = user.ImageUrl,
                    Articles = user.Articles.OrderByDescending(article => article.CreatedDate)
                        .ThenByDescending(article => article.ArticleId)
                        .Select(article => new GetArticleById
                        {
                            ArticleId = article.ArticleId,
                            Title = article.Title,
                            Content = article.Content,
                            CoverImageUrl = article.CoverImageUrl,
                            MainImageUrl = article.MainImageUrl,
                            CreatedDate = article.CreatedDate,
                            CategoryId = article.CategoryId,
                            AppUserId = article.AppUserId
                        }).ToList()
                })
                .ToListAsync();
            return Ok(values);
        }
    }
}
