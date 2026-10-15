using System.ComponentModel.DataAnnotations;

namespace AIBlog.WebUI.Dtos.CommentDtos;

public class CreateCommentDto
{
    [Range(1, int.MaxValue)]
    public int ArticleId { get; set; }
    [Required(ErrorMessage = "Yorum metni zorunludur.")]
    [StringLength(4000)]
    public string CommentDetail { get; set; } = string.Empty;
}
