using AIBlog.WebApi.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AIBlog.WebApi.Context;
using AIBlog.WebApi.Entities;
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

        [HttpGet]
        public IActionResult CategoryList()
        {
            var categories = _context.Categories.ToList();
            return Ok(categories);
        }
        [HttpGet("{id:int}")]
        public IActionResult GetCategory([FromRoute] int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }
        [HttpPost]
        public IActionResult CreateCategory([FromBody] CategoryRequest request)
        {
            var category = new Category
            {
                CategoryName = request.CategoryName
            };
            _context.Categories.Add(category);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetCategory), new { id = category.CategoryId }, category);
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateCategory([FromRoute] int id, [FromBody] CategoryRequest request)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            category.CategoryName = request.CategoryName;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteCategory([FromRoute] int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return Ok("Kategori başarıyla silindi.");
        }
    }
}
