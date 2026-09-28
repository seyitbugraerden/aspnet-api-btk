using System.ComponentModel.DataAnnotations;

namespace AIBlog.WebApi.Contracts;

public class CategoryRequest
{
    [Required]
    public required string CategoryName { get; set; }
}
