using System.ComponentModel.DataAnnotations;

namespace AIBlog.WebApi.Dtos.TradingVideoDtos;

public class CreateTradingVideoDto
{
    [Required(ErrorMessage = "Başlık zorunludur.")]
    [Display(Name = "Başlık")]
    public string Title { get; set; } = string.Empty;

    [Required(ErrorMessage = "Küçük görsel bağlantısı zorunludur.")]
    [Display(Name = "Küçük görsel bağlantısı")]
    public string ThumbnailImageUrl { get; set; } = string.Empty;

    [Required(ErrorMessage = "Video bağlantısı zorunludur.")]
    [Display(Name = "Video bağlantısı")]
    [Url(ErrorMessage = "Geçerli bir video URL adresi girin.")]
    public string EmbedVideoUrl { get; set; } = string.Empty;

}
