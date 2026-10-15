namespace AIBlog.WebApi.Dtos.CommentDtos;

public class UpdateCommentDto : CreateCommentDto
{
    public int CommentId { get; set; }
    public bool IsConfirmed { get; set; }
}
