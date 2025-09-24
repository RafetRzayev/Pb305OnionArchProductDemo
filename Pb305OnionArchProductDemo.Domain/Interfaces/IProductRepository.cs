using Pb305OnionArchProductDemo.Domain.Entities;

namespace Pb305OnionArchProductDemo.Domain.Interfaces;

public interface IProductRepository
{
    Task<IEnumerable<Product>> GetAllProductsAsync();
    Task<Product?> GetProductByIdAsync(int id);
    Task<Product> AddProductAsync(Product product);
    Task UpdateProductAsync(Product product);
    Task DeleteProductAsync(int id);
}
