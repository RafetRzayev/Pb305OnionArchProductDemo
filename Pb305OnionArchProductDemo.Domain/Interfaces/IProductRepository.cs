using Pb305OnionArchProductDemo.Domain.Entities;

namespace Pb305OnionArchProductDemo.Domain.Interfaces;

public interface IProductRepository : IRepository<Product>
{
    Task RemoveTagsFromProductAsync(int productId, List<int> tagIds);
}