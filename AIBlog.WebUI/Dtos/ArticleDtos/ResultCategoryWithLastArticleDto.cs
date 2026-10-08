namespace AIBlog.WebUI.Dtos.ArticleDtos
{
    public class ResultCategoryWithLastArticleDto
    {
        public int ArticleId { get; set; }
        public string? CategoryName { get; set; }
        public string? LastArticleTitle { get; set; }
        public string? LastArticleImage { get; set; }
        public DateTime LastArticleDate { get; set; }
    }
}
