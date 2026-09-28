using System.ComponentModel.DataAnnotations;

namespace AIBlog.WebApi.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public required string CategoryName { get; set; }
    }
}
