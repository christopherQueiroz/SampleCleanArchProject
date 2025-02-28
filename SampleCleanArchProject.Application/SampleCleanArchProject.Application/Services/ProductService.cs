using AutoMapper;
using SampleCleanArchProject.Application.DTOs;
using SampleCleanArchProject.Application.Interfaces;
using SampleCleanArchProject.Domain.Entities;
using SampleCleanArchProject.Domain.Interfaces;

namespace SampleCleanArchProject.Application.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _repository;
        private readonly IMapper _mapper;

        public ProductService(IProductRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products = await _repository.GetProductsAsync();
            return _mapper.Map<IEnumerable<ProductDto>>(products);
        }

        public async Task<ProductDto> GetById(int? id)
        {
            var product = await _repository.GetByIdAsync(id);
            return _mapper.Map<ProductDto>(product);
        }

        public async Task<ProductDto> GetProductCategory(int? id)
        {
            var product = await _repository.GetProductCategoryAsync(id);

            return _mapper.Map<ProductDto>(product);
        }

        public async Task Add(ProductDto product)
        {
            var productEntity = _mapper.Map<Product>(product);
            await _repository.CreateAsync(productEntity);
        }

        public async Task Update(ProductDto product)
        {
            var productEntity = _mapper.Map<Product>(product);
            await _repository.UpdateAsync(productEntity);
        }

        public async Task Remove(int? id)
        {
            var productEntity = _repository.GetByIdAsync(id).Result;

            await _repository.RemoveAsync(productEntity);
        }
    }
}