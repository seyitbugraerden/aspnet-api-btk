using System.ComponentModel.DataAnnotations;

namespace AIBlog.WebApi.Dtos.TradingVideoDtos;

public class ResultTradingVideoDto
{
    public int TradingVideoId { get; set; }
    public string Title { get; set; } = string.Empty;

    public string ThumbnailImageUrl { get; set; } = string.Empty;

    public string EmbedVideoUrl { get; set; } = string.Empty;

    public DateTime CreatedDate { get; set; }
}
