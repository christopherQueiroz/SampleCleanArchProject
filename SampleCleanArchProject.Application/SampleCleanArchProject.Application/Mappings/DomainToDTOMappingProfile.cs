using AutoMapper;
using SampleCleanArchProject.Application.DTOs;
using SampleCleanArchProject.Domain.Entities;

namespace SampleCleanArchProject.Application.Mappings
{
    public class DomainToDTOMappingProfile : Profile
    {
        public DomainToDTOMappingProfile()
        {
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}