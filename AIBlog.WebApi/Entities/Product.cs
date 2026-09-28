using Microsoft.EntityFrameworkCore;

namespace AIBlog.WebApi.Entities
{
    public class Product
    {
        public int ProductId { get; set; }
        public required string ProductName { get; set; }
        public int ProductStock { get; set; }
        [Precision(18, 2)]
        public decimal ProductPrice { get; set; }
    }
}
