using AutoMapper;
using AIBlog.WebApi.Entities;
using AIBlog.WebApi.Dtos.ArticleDtos;

namespace AIBlog.WebApi.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping()
        {
            CreateMap<Article, ResultArticleWithCategoryDto>()
                .ForMember(
                    dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category != null
                        ? src.Category.CategoryName
                        : string.Empty));
            CreateMap<CreateArticleDto, Article>().ReverseMap();
            CreateMap<Article, GetArticleById>().ReverseMap();
            CreateMap<Article, UpdateArticleDto>().ReverseMap();
            CreateMap<Article, ResultArticleWithHomeCategoryDto>()
                .ForMember(
                    dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category != null
                        ? src.Category.CategoryName
                        : string.Empty));
            CreateMap<Category, HomeCategoryDto>().ReverseMap();
            CreateMap<Article, ResultArticleSingleTech>()
                .ForMember(
                    dest => dest.CategoryName,
                    opt => opt.MapFrom(src => src.Category != null
                        ? src.Category.CategoryName
                        : string.Empty));
        }
    }
}
