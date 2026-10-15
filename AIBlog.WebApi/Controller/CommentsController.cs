using AIBlog.WebApi.Context;
using AIBlog.WebApi.Dtos.CommentDtos;
using AIBlog.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AIBlog.WebApi.Controller;

[Route("api/[controller]")]
[ApiController]
public class CommentsController : ControllerBase
{
    private readonly BlogAIContext _context;
    public CommentsController(BlogAIContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> CommentList(int? articleId, bool confirmedOnly = false)
    {
        if (articleId.HasValue && articleId <= 0) return BadRequest();
        var query = _context.Comments.AsNoTracking();
        if (articleId.HasValue) query = query.Where(comment => comment.ArticleId == articleId.Value);
        if (confirmedOnly) query = query.Where(comment => comment.IsConfirmed);
        return Ok(await ProjectComments(query.OrderByDescending(comment => comment.CommentDate)
            .ThenByDescending(comment => comment.CommentId)).ToListAsync());
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetComment(int id)
    {
        var comment = await ProjectComments(_context.Comments.AsNoTracking().Where(comment => comment.CommentId == id))
            .FirstOrDefaultAsync();
        if (comment == null) return NotFound();
        return Ok(comment);
    }

    [HttpPost]
    public async Task<IActionResult> CreateComment(CreateCommentDto model)
    {
        if (!await _context.Articles.AnyAsync(article => article.ArticleId == model.ArticleId))
            return BadRequest(new { message = "Makale bulunamadı." });
        if (!await _context.Users.AnyAsync(user => user.Id == model.AppUserId))
            return BadRequest(new { message = "Kullanıcı bulunamadı." });
        var comment = new Comment
        {
            ArticleId = model.ArticleId, AppUserId = model.AppUserId,
            CommentDetail = model.CommentDetail.Trim(), CommentDate = DateTime.Now,
            IsConfirmed = false, CommentStatus = "Onay Bekliyor"
        };
        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetComment), new { id = comment.CommentId }, new { comment.CommentId });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateComment(int id, UpdateCommentDto model)
    {
        if (id != model.CommentId) return BadRequest();
        var comment = await _context.Comments.FindAsync(id);
        if (comment == null) return NotFound();
        if (!await _context.Articles.AnyAsync(article => article.ArticleId == model.ArticleId))
            return BadRequest(new { message = "Makale bulunamadı." });
        if (!await _context.Users.AnyAsync(user => user.Id == model.AppUserId))
            return BadRequest(new { message = "Kullanıcı bulunamadı." });
        comment.ArticleId = model.ArticleId;
        comment.AppUserId = model.AppUserId;
        comment.CommentDetail = model.CommentDetail.Trim();
        comment.IsConfirmed = model.IsConfirmed;
        comment.CommentStatus = model.IsConfirmed ? "Onaylandı" : "Onay Bekliyor";
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteComment(int id)
    {
        var comment = await _context.Comments.FindAsync(id);
        if (comment == null) return NotFound();
        _context.Comments.Remove(comment);
        await _context.SaveChangesAsync();
        return NoContent();
    }

    private static IQueryable<ResultCommentDto> ProjectComments(IQueryable<Comment> query) =>
        query.Select(comment => new ResultCommentDto
        {
            CommentId = comment.CommentId, ArticleId = comment.ArticleId,
            AppUserId = comment.AppUserId,
            AuthorName = comment.AppUser.Name + " " + comment.AppUser.Surname,
            AuthorImageUrl = comment.AppUser.ImageUrl,
            CommentDate = comment.CommentDate, CommentDetail = comment.CommentDetail,
            IsConfirmed = comment.IsConfirmed, CommentStatus = comment.CommentStatus
        });
}
