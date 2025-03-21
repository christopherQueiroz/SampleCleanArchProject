using AutoMapper;
using SampleCleanArchProject.Application.DTOs;
using SampleCleanArchProject.Application.IOEntities;
using SampleCleanArchProject.Domain.Entities;

namespace SampleCleanArchProject.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<CategoryDto, Category>()
                .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != null))
                .ReverseMap();

            CreateMap<CategoryDto, CategoryRequest>()
                .ReverseMap();

            CreateMap<CategoryDto, CategoryResponse>()
               .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != null))
               .ReverseMap();


            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != null))
                .ReverseMap();

            CreateMap<ProductDto, ProductRequest>()
                .ReverseMap();

            CreateMap<ProductDto, ProductResponse>()
                .ForMember(dest => dest.Id, opt => opt.Condition(src => src.Id != null))
                .ReverseMap();

        }
    }
}