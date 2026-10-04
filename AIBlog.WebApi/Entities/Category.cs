using System.ComponentModel.DataAnnotations;

namespace AIBlog.WebApi.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public List<Article> Articles { get; set; }
    }
}
