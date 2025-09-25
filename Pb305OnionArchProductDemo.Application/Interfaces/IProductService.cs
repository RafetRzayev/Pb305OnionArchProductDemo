using Pb305OnionArchProductDemo.Application.Dtos;
using Pb305OnionArchProductDemo.Domain.Entities;

namespace Pb305OnionArchProductDemo.Application.Interfaces;

public interface IProductService : ICrudService<ProductDto, CreateProductDto, UpdateProductDto, Product>
{
    Task RemoveTagsFromProductAsync(RemoveTagsFromProductDto removeTagsFromProductDto);
}
