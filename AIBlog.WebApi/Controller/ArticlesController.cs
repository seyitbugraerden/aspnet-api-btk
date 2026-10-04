using AutoMapper;
using AIBlog.WebApi.Context;
using AIBlog.WebApi.Dtos.ArticleDtos;
using AIBlog.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AIBlog.WebApi.Controller
{
    [ApiController]
    [Route("api/[controller]")]
    public class ArticlesController : ControllerBase
    {
        private readonly BlogAIContext _context;
        private readonly IMapper _mapper;

        public ArticlesController(BlogAIContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpGet]
        public IActionResult ArticleList()
        {
            var values = _context.Articles.Include(x => x.Category).ToList();
            var dto = _mapper.Map<List<ResultArticleWithCategoryDto>>(values);
            return Ok(dto);
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
