using AutoMapper;
using SampleCleanArchProject.Application.DTOs;
using SampleCleanArchProject.Application.Interfaces;
using SampleCleanArchProject.Domain.Entities;
using SampleCleanArchProject.Domain.Interfaces;

namespace SampleCleanArchProject.Application.Services
{
    public class CategoryService : ICategoryService
    {
        private ICategoryRepository _repository;
        private readonly IMapper _mapper;

        public CategoryService(ICategoryRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;
        }

        public async Task Add(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _repository.CreateAsync(category);
        }

        public async Task<CategoryDto> GetById(int? id)
        {
            var category = await _repository.GetByIdAsync(id);

            return _mapper.Map<CategoryDto>(category);
        }

        public async Task<IEnumerable<CategoryDto>> GetCategories()
        {
            var categories = await _repository.GetCategoriesAsync();

            return _mapper.Map<IEnumerable<CategoryDto>>(categories);
        }

        public async Task Remove(int? id)
        {
            var category = _repository.GetByIdAsync(id).Result;
            await _repository.RemoveAsync(category);
        }

        public async Task Update(CategoryDto categoryDto)
        {
            var category = _mapper.Map<Category>(categoryDto);
            await _repository.UpdateAsync(category);
        }
    }
}