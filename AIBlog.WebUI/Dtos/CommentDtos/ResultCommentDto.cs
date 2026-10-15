namespace AIBlog.WebUI.Dtos.CommentDtos;

public class ResultCommentDto
{
    public int CommentId { get; set; }
    public int ArticleId { get; set; }
    public string AppUserId { get; set; } = string.Empty;
    public string AuthorName { get; set; } = string.Empty;
    public string? AuthorImageUrl { get; set; }
    public DateTime CommentDate { get; set; }
    public string CommentDetail { get; set; } = string.Empty;
    public bool IsConfirmed { get; set; }
    public string CommentStatus { get; set; } = string.Empty;
}
