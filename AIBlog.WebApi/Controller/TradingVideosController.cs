using AIBlog.WebApi.Context;
using AIBlog.WebApi.Dtos.TradingVideoDtos;
using AIBlog.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AIBlog.WebApi.Controller;

[ApiController]
[Route("api/[controller]")]
public class TradingVideosController : ControllerBase
{
    private readonly BlogAIContext _context;

    public TradingVideosController(BlogAIContext context) => _context = context;

    [HttpGet]
    public async Task<IActionResult> TradingVideoList()
    {
        var videos = await _context.TradingVideos.AsNoTracking()
            .OrderByDescending(video => video.CreatedDate).ThenByDescending(video => video.TradingVideoId)
            .Select(video => new ResultTradingVideoDto
            {
                TradingVideoId = video.TradingVideoId, Title = video.Title,
                ThumbnailImageUrl = video.ThumbnailImageUrl, EmbedVideoUrl = video.EmbedVideoUrl,
                CreatedDate = video.CreatedDate
            }).ToListAsync();
        return Ok(videos);
    }

    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetTradingVideo(int id)
    {
        var video = await _context.TradingVideos.AsNoTracking().FirstOrDefaultAsync(video => video.TradingVideoId == id);
        if (video == null) return NotFound();
        return Ok(new ResultTradingVideoDto
        {
            TradingVideoId = video.TradingVideoId, Title = video.Title,
            ThumbnailImageUrl = video.ThumbnailImageUrl, EmbedVideoUrl = video.EmbedVideoUrl,
            CreatedDate = video.CreatedDate
        });
    }

    [HttpPost]
    public async Task<IActionResult> CreateTradingVideo(CreateTradingVideoDto model)
    {
        var video = new TradingVideo
        {
            Title = model.Title.Trim(), ThumbnailImageUrl = model.ThumbnailImageUrl.Trim(),
            EmbedVideoUrl = model.EmbedVideoUrl.Trim(), CreatedDate = DateTime.Now
        };
        _context.TradingVideos.Add(video);
        await _context.SaveChangesAsync();
        return CreatedAtAction(nameof(GetTradingVideo), new { id = video.TradingVideoId }, new { video.TradingVideoId });
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateTradingVideo(int id, UpdateTradingVideoDto model)
    {
        if (id != model.TradingVideoId) return BadRequest();
        var video = await _context.TradingVideos.FindAsync(id);
        if (video == null) return NotFound();
        video.Title = model.Title.Trim();
        video.ThumbnailImageUrl = model.ThumbnailImageUrl.Trim();
        video.EmbedVideoUrl = model.EmbedVideoUrl.Trim();
        await _context.SaveChangesAsync();
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteTradingVideo(int id)
    {
        var video = await _context.TradingVideos.FindAsync(id);
        if (video == null) return NotFound();
        _context.TradingVideos.Remove(video);
        await _context.SaveChangesAsync();
        return NoContent();
    }
}
