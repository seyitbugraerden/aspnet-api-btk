using System.ComponentModel.DataAnnotations;

namespace AIBlog.WebUI.Dtos.UserDtos;

public class CreateUserDto
{
    [Required(ErrorMessage = "Kullanıcı adı zorunludur.")]
    public string UserName { get; set; } = string.Empty;
    [Required(ErrorMessage = "Ad zorunludur.")]
    public string Name { get; set; } = string.Empty;
    [Required(ErrorMessage = "Soyad zorunludur.")]
    public string Surname { get; set; } = string.Empty;
    [Required(ErrorMessage = "E-posta zorunludur.")]
    [EmailAddress(ErrorMessage = "Geçerli bir e-posta girin.")]
    public string Email { get; set; } = string.Empty;
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? ImageUrl { get; set; }
    [Required(ErrorMessage = "Şifre zorunludur.")]
    [DataType(DataType.Password)]
    public string Password { get; set; } = string.Empty;
}
