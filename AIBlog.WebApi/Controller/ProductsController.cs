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
        [HttpGet("{id:int}")]
        public IActionResult GetProduct([FromRoute] int id)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product);
        }
        [HttpPost]
        public IActionResult CreateProduct([FromBody] ProductRequest request)
        {
            var product = new Product
            {
                ProductName = request.ProductName,
                ProductStock = request.ProductStock,
                ProductPrice = request.ProductPrice
            };
            _context.Products.Add(product);
            _context.SaveChanges();
            return CreatedAtAction(nameof(GetProduct), new { id = product.ProductId }, product);
        }
        [HttpPut("{id:int}")]
        public IActionResult UpdateProduct([FromRoute] int id, [FromBody] ProductRequest request)
        {
            var product = _context.Products.Find(id);
            if (product == null)
            {
                return NotFound();
            }
            product.ProductName = request.ProductName;
            product.ProductStock = request.ProductStock;
            product.ProductPrice = request.ProductPrice;
            _context.SaveChanges();
            return NoContent();
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteProduct([FromRoute] int id)
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
