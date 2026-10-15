using AIBlog.WebUI.Dtos.CommentDtos;
using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebUI.ViewComponents.BlogDetailComponents;

public class _BlogDetailAddCommentComponentArtial : ViewComponent
{
    public IViewComponentResult Invoke(int articleId = 0) => View(new CreateCommentDto { ArticleId = articleId });
}
