using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AIBlog.WebApi.Dtos.ArticleDtos
{
    public class ResultArticleWithHomeCategoryDto
    {
        public int ArticleId { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? CategoryName { get; set; }
        public bool IsFeatureSlider { get; set; }
        public string FeatureSliderImageUrl { get; set; }
        public string? Name { get; set; }
        public string? Surname { get; set; }
        public string? ImageUrl { get; set; }
    }
}