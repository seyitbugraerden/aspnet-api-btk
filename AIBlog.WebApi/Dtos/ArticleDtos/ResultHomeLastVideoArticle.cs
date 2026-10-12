using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIBlog.WebApi.Dtos.ArticleDtos
{
    public class ResultHomeLastVideoArticle
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public string MainImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public int? CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? ImageUrl { get; set; }
        public string? MainVideoUrl { get; set; }
        public bool? IsLastVideoArticle { get; set; }
    }
}