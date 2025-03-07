using Microsoft.EntityFrameworkCore;
using SampleCleanArchProject.Domain.Entities;
using SampleCleanArchProject.Domain.Interfaces;
using SampleCleanArchProject.Infra.Data.Context;
using System.Data;

namespace SampleCleanArchProject.Infra.Data.Repositories
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ApplicationDbContext _categoryContext;
       // private readonly IDbConnection _connection;
        public CategoryRepository(ApplicationDbContext context)
        {
            this._categoryContext = context;
           // this._connection = connection;
        }
        public async Task<Category> CreateAsync(Category category)
        {
            _categoryContext.Add(category);
            await _categoryContext.SaveChangesAsync();

            return category;
        }

        public async Task<Category> GetByIdAsync(int? id)
        {
            return await _categoryContext.Categories.FindAsync(id);
        }

        public async Task<IEnumerable<Category>> GetCategoriesAsync()
        {
            return await _categoryContext.Categories.ToListAsync();
        }

        public async Task<Category> RemoveAsync(Category category)
        {
            _categoryContext.Remove(category);
            await _categoryContext.SaveChangesAsync();

            return category;
        }

        public async Task<Category> UpdateAsync(Category category)
        {
            _categoryContext.Update(category);
            await _categoryContext.SaveChangesAsync();

            return category;
        }
    }
}