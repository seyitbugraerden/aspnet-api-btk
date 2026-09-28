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
    public class ProductsController : ControllerBase
    {
        private readonly BlogAIContext _context;

        public ProductsController(BlogAIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetProducts()
        {
            var products = _context.Products.ToList();
            return Ok(products);
        }
        [HttpGet("{id}")]
        public IActionResult GetProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public IActionResult CreateProduct(Product product)
        {
            _context.Products.Add(product);
            _context.SaveChanges();
            return Ok("Ürün başarıyla oluşturuldu.");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteProduct(int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            _context.Products.Remove(product);
            _context.SaveChanges();
            return Ok("Ürün başarıyla silindi.");
        }
    }
}