namespace Pb305OnionArchProductDemo.Domain.Entities;

public class Tag : Entity
{
    public string Name { get; set; } = null!;

    public ICollection<ProductTag> ProductTags { get; set; } = [];
}
