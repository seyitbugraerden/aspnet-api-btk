using System.ComponentModel.DataAnnotations;

namespace AIBlog.WebApi.Dtos.CommentDtos;

public class CreateCommentDto
{
    [Range(1, int.MaxValue)]
    public int ArticleId { get; set; }
    [Required]
    public string AppUserId { get; set; } = string.Empty;
    [Required(ErrorMessage = "Yorum metni zorunludur.")]
    [StringLength(4000)]
    public string CommentDetail { get; set; } = string.Empty;
}
