using AutoMapper;
using Pb305OnionArchProductDemo.Application.Dtos;
using Pb305OnionArchProductDemo.Application.Interfaces;
using Pb305OnionArchProductDemo.Domain.Entities;
using Pb305OnionArchProductDemo.Domain.Interfaces;

namespace Pb305OnionArchProductDemo.Application.Services;

public class ProductService : CrudService<ProductDto, CreateProductDto, UpdateProductDto, Product>, IProductService
{
    private readonly IProductRepository _productRepository;

    public ProductService(IRepository<Product> repository, IMapper mapper, IProductRepository productRepository) : base(repository, mapper)
    {
        _productRepository = productRepository;
    }

    public async override Task<IEnumerable<ProductDto>> GetAllAsync()
    {
        var products = await _productRepository.GetAllAsync();

        var dtos = Mapper.Map<IEnumerable<ProductDto>>(products);

        return dtos;
    }

    public Task RemoveTagsFromProductAsync(RemoveTagsFromProductDto removeTagsFromProductDto)
    {
        return _productRepository.RemoveTagsFromProductAsync(removeTagsFromProductDto.ProductId, removeTagsFromProductDto.TagIds);
    }
}