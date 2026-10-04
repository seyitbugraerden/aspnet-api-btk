using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using AIBlog.WebApi.Context;
using AIBlog.WebApi.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace AIBlog.WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly BlogAIContext _context;

        public ArticlesController(BlogAIContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ArticleList()
        {
            var articles = _context.Articles.ToList();
            return Ok(articles);
        }
        [HttpPost]
        public IActionResult CreateArticle(Article article)
        {
            article.CreatedDate = DateTime.Now;
            _context.Articles.Add(article);
            _context.SaveChanges();
            return Ok(article);
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteArticle(int id)
        {
            var article = _context.Articles.Find(id);
            if (article == null)
            {
                return NotFound();
            }
            _context.Articles.Remove(article);
            _context.SaveChanges();
            return Ok(article);
        }

        [HttpPut]
        public IActionResult UpdateArticle(Article article)
        {
            _context.Articles.Update(article);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }
    }
}
