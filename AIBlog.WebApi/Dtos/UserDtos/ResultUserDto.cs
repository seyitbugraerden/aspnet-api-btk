using AIBlog.WebApi.Dtos.ArticleDtos;

namespace AIBlog.WebApi.Dtos.UserDtos;

public class ResultUserDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public List<GetArticleById> Articles { get; set; } = new();
}
