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
        public IActionResult CreateArticle(CreateArticleDto createArticleDto)
        {
            createArticleDto.CreatedDate = DateTime.Now;
            var values = _mapper.Map<Article>(createArticleDto);
            _context.Articles.Add(values);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteArticle(int id)
        {
            var value = _context.Articles.Find(id);
            return Ok(_mapper.Map<GetArticleById>(value));
        }

        [HttpPut]
        public IActionResult UpdateArticle(UpdateArticleDto updateArticleDto)
        {
            var value = _mapper.Map<Article>(updateArticleDto);
            _context.Articles.Update(value);
            _context.SaveChanges();
            return Ok("Güncelleme işlemi başarılı");
        }

        [HttpGet("GetArticlesFeatureSliderByTrue")]
        public IActionResult GetArticlesFeatureSliderByTrue()
        {
            var values = _context.Articles.Where(x => x.IsFeatureSlider == true).Include(x => x.Category).Include(y => y.AppUser).ToList();
            return Ok(value: _mapper.Map<List<ResultArticleWithHomeCategoryDto>>(values));
        }

        [HttpGet("GetLastTechnologyArticles")]
        public IActionResult GetLastTechnologyArticles()
        {
            var values = _context.Articles.Include(x => x.Category).Where(x => x.Category.CategoryName == "Teknoloji").Include(y => y.AppUser).OrderByDescending(x => x.ArticleId).FirstOrDefault();
            return Ok(_mapper.Map<ResultArticleSingleTech>(values));
        }
        [HttpGet("GetLastSportArticles")]
        public IActionResult GetLastSportArticles()
        {
            var values = _context.Articles.Include(x => x.Category).Where(x => x.Category.CategoryName == "Spor").Include(y => y.AppUser).OrderByDescending(x => x.ArticleId).FirstOrDefault();
            return Ok(_mapper.Map<ResultArticleSingleSport>(values));
        }
        [HttpGet("GetLastFoodArticles")]
        public IActionResult GetLastFoodArticles()
        {
            var values = _context.Articles.Include(x => x.Category).Where(x => x.Category.CategoryName == "Yemek").Include(y => y.AppUser).OrderByDescending(x => x.ArticleId).FirstOrDefault();
            return Ok(_mapper.Map<ResultArticleSingleFood>(values));
        }
    }
}
