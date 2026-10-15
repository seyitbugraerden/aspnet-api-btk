namespace AIBlog.WebUI.Dtos.ArticleDtos;

public class GetArticleByIdDto
{
    public string? AppUserId { get; set; }
    public int ArticleId { get; set; }
    public string Title { get; set; } = string.Empty;
    public string CoverImageUrl { get; set; } = string.Empty;
    public string MainImageUrl { get; set; } = string.Empty;
    public string Content { get; set; } = string.Empty;
    public DateTime CreatedDate { get; set; }
    public int? CategoryId { get; set; }
}
