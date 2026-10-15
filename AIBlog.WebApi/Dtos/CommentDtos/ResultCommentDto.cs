using System;
using AIBlog.WebApi.Entities;

namespace AIBlog.WebApi.Dtos.CommentDtos;

public class ResultCommentDto
{
    public int CommentId { get; set; }
    public string AppUserId { get; set; }
    public AppUser AppUser { get; set; }
    public DateTime CommentDate { get; set; }
    public string CommentDetail { get; set; }
    public bool IsConfirmed { get; set; }
    public string CommentStatus { get; set; }
}
