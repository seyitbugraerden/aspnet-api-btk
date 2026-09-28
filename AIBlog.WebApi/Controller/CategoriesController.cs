using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIBlog.WebApi.Context;
using Microsoft.AspNetCore.Mvc;

namespace AIBlog.WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class CategoriesController : ControllerBase
    {
        private readonly BlogAIContext _context;
        // DB'den veri okuma işlemleri için BlogAIContext sınıfını kullanıyoruz. Bu sınıf, veritabanı bağlantısı ve veri erişimi için gerekli yapılandırmayı içerir.

        public CategoriesController(BlogAIContext context)
        {
            _context = context;
        }
        // Dependency Injection (Bağımlılık Enjeksiyonu) kullanarak BlogAIContext sınıfını CategoriesController'a enjekte ediyoruz. Bu sayede veritabanı işlemlerini gerçekleştirebiliriz.

        
    }
}