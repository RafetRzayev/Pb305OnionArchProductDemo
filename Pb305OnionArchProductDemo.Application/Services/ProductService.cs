using Pb305OnionArchProductDemo.Application.Dtos;
using Pb305OnionArchProductDemo.Application.Interfaces;
using Pb305OnionArchProductDemo.Domain.Entities;
using Pb305OnionArchProductDemo.Domain.Interfaces;

namespace Pb305OnionArchProductDemo.Application.Services;

public class ProductService : IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IProductRepository productRepository)
    {
        _productRepository = productRepository;
    }

    public async Task<ProductDto> AddProductAsync(CreateProductDto createProductDto)
    {
        var product = new Product
        {
            Name = createProductDto.Name,
            Price = createProductDto.Price
        };

        var createdProduct = await _productRepository.AddProductAsync(product);

        return new ProductDto
        {
            Id = createdProduct.Id,
            Name = createdProduct.Name,
            Price = createdProduct.Price
        };
    }

    public async Task DeleteProductAsync(int id)
    {
        await _productRepository.DeleteProductAsync(id);
    }

    public async Task<IEnumerable<ProductDto>> GetAllProductsAsync()
    {
        var products =  await _productRepository.GetAllProductsAsync();

        var productDtos = products.Select(p => new ProductDto
        {
            Id = p.Id,
            Name = p.Name,
            Price = p.Price
        });

        return productDtos;
    }

    public async Task<ProductDto?> GetProductByIdAsync(int id)
    {
        var product = await _productRepository.GetProductByIdAsync(id);

        if (product == null)
            return null;           

        var productDto = new ProductDto
        {
            Id = product.Id,
            Name = product.Name,
            Price = product.Price
        };

        return productDto;
    }

    public Task UpdateProductAsync(UpdateProductDto updateProductDto)
    {
        var product = new Product
        {
            Id = updateProductDto.Id,
            Name = updateProductDto.Name,
            Price = updateProductDto.Price
        };

        return _productRepository.UpdateProductAsync(product);
    }
}
