using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AIBlog.WebApi.Controller
{
    [Route("[controller]")]
    public class Registers : Controller
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
            await _userManager.CreateAsync(appUser, registerDto.Password);
            return Ok("Kullanıcı başarıyla oluşturuldu.");
        }
    }
}