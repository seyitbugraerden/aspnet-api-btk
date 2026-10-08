using AIBlog.WebApi.Dtos.RegisterDtos;
using AIBlog.WebApi.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebApi.Controller
{
    [ApiController]
    [Route("[controller]")]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<AppUser> _userManager;

        public RegistersController(UserManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser(UserRegisterDto registerDto)
        {
            AppUser appUser = new AppUser
            {
                UserName = registerDto.UserName,
                Email = registerDto.Email,
                Name = registerDto.Name,
                Surname = registerDto.Surname,
                Title = "Default Title",
                Description = "Default Description",
                ImageUrl = "default-image-url.jpg"
            };
            var result = await _userManager.CreateAsync(appUser, registerDto.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            return Ok("Kullanıcı başarıyla oluşturuldu.");
        }
    }
}
