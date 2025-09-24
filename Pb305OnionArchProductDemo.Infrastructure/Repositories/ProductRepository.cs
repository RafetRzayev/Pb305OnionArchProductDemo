using Microsoft.EntityFrameworkCore;
using Pb305OnionArchProductDemo.Domain.Entities;
using Pb305OnionArchProductDemo.Domain.Interfaces;
using Pb305OnionArchProductDemo.Infrastructure.DataContext;

namespace Pb305OnionArchProductDemo.Infrastructure.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppDbContext _dbContext;

    public ProductRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Product> AddProductAsync(Product product)
    {
        var entityEntry = await _dbContext.Products.AddAsync(product);
        await _dbContext.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task DeleteProductAsync(int id)
    {
        var product = _dbContext.Products.Find(id);

        if (product != null)
        {
            _dbContext.Products.Remove(product);
            await _dbContext.SaveChangesAsync();

            return;
        }

        throw new Exception($"Product not found, with given id  : {id}");
    }

    public async Task<IEnumerable<Product>> GetAllProductsAsync()
    {
        var products = await _dbContext.Products.ToListAsync();

        return products;
    }

    public async Task<Product?> GetProductByIdAsync(int id)
    {
        var product = await _dbContext.Products.FindAsync(id);

        return product;
    }

    public async Task UpdateProductAsync(Product product)
    {
        var existingProduct = await _dbContext
            .Products
            .AsNoTracking()
            .FirstOrDefaultAsync(x=>x.Id == product.Id);

        if (existingProduct == null)
            throw new Exception($"Product not found, with given id  : {product.Id}");

        _dbContext.Products.Update(product);
        await _dbContext.SaveChangesAsync();
    }
}
