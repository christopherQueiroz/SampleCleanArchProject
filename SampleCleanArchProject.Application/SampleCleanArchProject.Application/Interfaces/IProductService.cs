
using SampleCleanArchProject.Application.DTOs;

namespace SampleCleanArchProject.Application.Interfaces
{
    public interface IProductService
    {
        Task<IEnumerable<ProductDto>> GetProducts();
        Task<ProductDto> GetById(int? id);
        Task Add(ProductDto product);
        Task Update(ProductDto product);
        Task Remove(int? id);
    }
}