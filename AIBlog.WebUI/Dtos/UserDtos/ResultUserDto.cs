using AIBlog.WebUI.Dtos.ArticleDtos;

namespace AIBlog.WebUI.Dtos.UserDtos;

public class ResultUserDto
{
    public string Id { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
    public string Surname { get; set; } = string.Empty;
    public string ImageUrl { get; set; } = string.Empty;
    public List<GetArticleByIdDto> Articles { get; set; } = new();
}
