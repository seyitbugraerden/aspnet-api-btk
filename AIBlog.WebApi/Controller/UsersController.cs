using AIBlog.WebApi.Entities;
using AIBlog.WebApi.Context;
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
        private readonly BlogAIContext _context;
        public UsersController(UserManager<AppUser> userManager, BlogAIContext context)
        {
            _userManager = userManager;
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> UserList()
        {
            var values = await _userManager.Users
                .AsNoTracking()
                .Select(user => new ResultUserDto
                {
                    Id = user.Id,
                    UserName = user.UserName ?? string.Empty,
                    Email = user.Email,
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
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            return Ok(new UpdateUserDto
            {
                Id = user.Id, UserName = user.UserName ?? string.Empty,
                Email = user.Email ?? string.Empty, Name = user.Name, Surname = user.Surname,
                Title = user.Title, Description = user.Description, ImageUrl = user.ImageUrl
            });
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserDto model)
        {
            var user = new AppUser
            {
                UserName = model.UserName, Email = model.Email,
                Name = model.Name, Surname = model.Surname,
                Title = model.Title ?? string.Empty, Description = model.Description ?? string.Empty,
                ImageUrl = model.ImageUrl ?? string.Empty
            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded) return BadRequest(result.Errors.Select(error => error.Description));
            return CreatedAtAction(nameof(GetUser), new { id = user.Id }, new { user.Id });
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(string id, UpdateUserDto model)
        {
            if (id != model.Id) return BadRequest(new[] { "Kullanıcı ID bilgisi eşleşmiyor." });
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            user.UserName = model.UserName;
            user.Email = model.Email;
            user.Name = model.Name;
            user.Surname = model.Surname;
            user.Title = model.Title ?? string.Empty;
            user.Description = model.Description ?? string.Empty;
            user.ImageUrl = model.ImageUrl ?? string.Empty;
            var result = await _userManager.UpdateAsync(user);
            if (!result.Succeeded) return BadRequest(result.Errors.Select(error => error.Description));
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(string id)
        {
            var user = await _userManager.FindByIdAsync(id);
            if (user == null) return NotFound();
            await using var transaction = await _context.Database.BeginTransactionAsync();
            await _context.Articles.Where(article => article.AppUserId == id)
                .ExecuteUpdateAsync(setters => setters.SetProperty(article => article.AppUserId, (string?)null));
            var result = await _userManager.DeleteAsync(user);
            if (!result.Succeeded) return BadRequest(result.Errors.Select(error => error.Description));
            await transaction.CommitAsync();
            return NoContent();
        }
    }
}
