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
            var values = _context.Articles.Include(x => x.Category).Include(x => x.AppUser).ToList();
            var dto = _mapper.Map<List<ResultArticleWithCategoryDto>>(values);
            return Ok(dto);
        }
        [HttpPost]
        public IActionResult CreateArticle(CreateArticleDto createArticleDto)
        {
            if (createArticleDto.AppUserId != null && !_context.Users.Any(x => x.Id == createArticleDto.AppUserId))
                return BadRequest("Seçilen yazar bulunamadı.");
            createArticleDto.CreatedDate = DateTime.Now;
            var values = _mapper.Map<Article>(createArticleDto);
            _context.Articles.Add(values);
            _context.SaveChanges();
            return Ok("Ekleme işlemi başarılı");
        }
        [HttpGet("{id:int}")]
        public IActionResult GetArticle(int id)
        {
            var value = _context.Articles.Find(id);
            if (value == null) return NotFound();
            return Ok(_mapper.Map<GetArticleById>(value));
        }
        [HttpDelete("{id:int}")]
        public IActionResult DeleteArticle(int id)
        {
            var value = _context.Articles.Find(id);
            if (value == null) return NotFound();
            _context.Articles.Remove(value);
            _context.SaveChanges();
            return Ok("Silme işlemi başarılı");
        }
        [HttpPut]
        public IActionResult UpdateArticle(UpdateArticleDto updateArticleDto)
        {
            var value = _context.Articles.Find(updateArticleDto.ArticleId);
            if (value == null) return NotFound();
            if (updateArticleDto.AppUserId != null && !_context.Users.Any(x => x.Id == updateArticleDto.AppUserId))
                return BadRequest("Seçilen yazar bulunamadı.");

            value.Title = updateArticleDto.Title;
            value.CoverImageUrl = updateArticleDto.CoverImageUrl;
            value.MainImageUrl = updateArticleDto.MainImageUrl;
            value.Content = updateArticleDto.Content;
            value.CategoryId = updateArticleDto.CategoryId;
            value.AppUserId = updateArticleDto.AppUserId;
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
        [HttpGet("GetLastArticlesOfDifferentCategories")]
        public IActionResult GetLastArticlesOfDifferentCategories()
        {
            var values = _context.Articles
                .AsNoTracking()
                .Where(article => article.CategoryId != null &&
                    article.ArticleId == _context.Articles
                        .Where(x => x.CategoryId == article.CategoryId)
                        .OrderByDescending(x => x.CreatedDate)
                        .ThenByDescending(x => x.ArticleId)
                        .Select(x => x.ArticleId)
                        .FirstOrDefault())
                .Include(article => article.Category)
                .Include(article => article.AppUser)
                .OrderBy(article => article.Category.CategoryName)
                .ToList();

            return Ok(_mapper.Map<List<ResultArticleLastArticles>>(values));
        }
        [HttpGet("GetTrendingArticles")]
        public IActionResult GetTrendingArticles()
        {
            var values = _context.Articles.Where(x => x.IsTrendingStories == true).Include(x => x.Category).Include(y => y.AppUser).ToList();
            return Ok(_mapper.Map<List<ResultArticleTrendingDto>>(values));
        }
        [HttpGet("GetHomeLastArticles")]
        public IActionResult GetHomeLastArticles()
        {
            var values = _context.Articles.Where(x => x.IsLastArticle == true).Include(x => x.Category).Include(y => y.AppUser).OrderByDescending(x => x.CreatedDate)
    .ThenByDescending(x => x.ArticleId).ToList();
            return Ok(_mapper.Map<List<ResultHomeLastArticle>>(values));
        }
        [HttpGet("GetHomeLastVideoArticles")]
        public IActionResult GetHomeLastVideoArticles()
        {
            var values = _context.Articles.Where(x => x.IsLastVideoArticle == true).Include(x => x.Category).Include(y => y.AppUser).OrderByDescending(x => x.CreatedDate)
    .ThenByDescending(x => x.ArticleId).ToList();
            return Ok(_mapper.Map<List<ResultHomeLastVideoArticle>>(values));
        }
    }
}
