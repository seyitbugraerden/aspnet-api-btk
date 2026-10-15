using System;

namespace AIBlog.WebUI.Dtos.CategoryDtos;

public class GetCategoryByIdDto
{
    public int CategoryId { get; set; }
    public string CategoryName { get; set; }
}
