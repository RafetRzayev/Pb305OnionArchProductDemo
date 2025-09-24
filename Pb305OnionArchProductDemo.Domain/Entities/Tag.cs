namespace Pb305OnionArchProductDemo.Domain.Entities;

public class Tag
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;

    public ICollection<ProductTag> ProductTags { get; set; } = [];
}
