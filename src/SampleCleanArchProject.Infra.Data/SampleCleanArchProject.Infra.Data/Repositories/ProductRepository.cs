using Microsoft.EntityFrameworkCore;
using SampleCleanArchProject.Domain.Entities;
using SampleCleanArchProject.Domain.Interfaces;
using SampleCleanArchProject.Infra.Data.Context;
using System.Data;

namespace SampleCleanArchProject.Infra.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly ApplicationDbContext _productContext;
       // private readonly IDbConnection _connection;

        public ProductRepository(ApplicationDbContext context)
        {
            this._productContext = context;
        }

        public async Task<Product> CreateAsync(Product product)
        {
            _productContext.Add(product);
            await _productContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> GetByIdAsync(int? id)
        {
            return await _productContext.Products.FindAsync(id);
        }

        public async Task<IEnumerable<Product>> GetProductsAsync()
        {
            return await _productContext.Products.ToListAsync();
        }

        public async Task<Product> RemoveAsync(Product product)
        {
            _productContext.Remove(product);
            await _productContext.SaveChangesAsync();

            return product;
        }

        public async Task<Product> UpdateAsync(Product product)
        {
            _productContext.Update(product);
            await _productContext.SaveChangesAsync();

            return product;
        }

    }
}