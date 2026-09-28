using System.ComponentModel.DataAnnotations;

namespace AIBlog.WebApi.Contracts;

public class ProductRequest
{
    [Required]
    public required string ProductName { get; set; }
    public int ProductStock { get; set; }
    public decimal ProductPrice { get; set; }
}
