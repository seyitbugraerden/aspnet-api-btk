using System.ComponentModel.DataAnnotations;

namespace AIBlog.WebUI.Dtos.CategoryDtos;

public class CreateCategoryDto
{
    public int CategoryId { get; set; }

    [Required(ErrorMessage = "Kategori adı zorunludur.")]
    [Display(Name = "Kategori Adı")]
    public string CategoryName { get; set; } = string.Empty;
}
