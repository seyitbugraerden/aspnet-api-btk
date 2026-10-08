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
            CreateMap<Category, HomeCategoryDto>().ReverseMap();

            CreateMap<Article, ResultArticleWithHomeCategoryDto>()
                .ForMember(dest => dest.CategoryName,
                    opt => opt.MapFrom(src =>
                        src.Category != null ? src.Category.CategoryName : null))
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src =>
                        src.AppUser != null ? src.AppUser.Name : null))
                .ForMember(dest => dest.Surname,
                    opt => opt.MapFrom(src =>
                        src.AppUser != null ? src.AppUser.Surname : null))
                .ForMember(dest => dest.ImageUrl,
                    opt => opt.MapFrom(src =>
                        src.AppUser != null ? src.AppUser.ImageUrl : null));

            CreateMap<Article, ResultArticleSingleTech>()
                .ForMember(dest => dest.CategoryName,
                    opt => opt.MapFrom(src =>
                        src.Category != null ? src.Category.CategoryName : null))
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src =>
                        src.AppUser != null ? src.AppUser.Name : null))
                .ForMember(dest => dest.Surname,
                    opt => opt.MapFrom(src =>
                        src.AppUser != null ? src.AppUser.Surname : null))
                .ForMember(dest => dest.ImageUrl,
                    opt => opt.MapFrom(src =>
                        src.AppUser != null ? src.AppUser.ImageUrl : null));

            CreateMap<Article, ResultArticleSingleSport>()
                .ForMember(dest => dest.CategoryName,
                    opt => opt.MapFrom(src =>
                        src.Category != null ? src.Category.CategoryName : null))
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src =>
                        src.AppUser != null ? src.AppUser.Name : null))
                .ForMember(dest => dest.Surname,
                    opt => opt.MapFrom(src =>
                        src.AppUser != null ? src.AppUser.Surname : null))
                .ForMember(dest => dest.ImageUrl,
                    opt => opt.MapFrom(src =>
                        src.AppUser != null ? src.AppUser.ImageUrl : null));

            CreateMap<Article, ResultArticleSingleFood>()
                .ForMember(dest => dest.CategoryName,
                    opt => opt.MapFrom(src =>
                        src.Category != null ? src.Category.CategoryName : null))
                .ForMember(dest => dest.Name,
                    opt => opt.MapFrom(src =>
                        src.AppUser != null ? src.AppUser.Name : null))
                .ForMember(dest => dest.Surname,
                    opt => opt.MapFrom(src =>
                        src.AppUser != null ? src.AppUser.Surname : null))
                .ForMember(dest => dest.ImageUrl,
                    opt => opt.MapFrom(src =>
                        src.AppUser != null ? src.AppUser.ImageUrl : null));
        }
    }
}
