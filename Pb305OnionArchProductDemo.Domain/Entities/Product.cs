namespace Pb305OnionArchProductDemo.Domain.Entities;

public class Product : Entity
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public ICollection<ProductTag> ProductTags { get; set; } = [];
}