namespace Pb305OnionArchProductDemo.Application.Dtos;

public class ProductDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public decimal Price { get; set; }
    public List<TagDto>? Tags { get; set; } = [];
}

public class CreateProductDto
{
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }
    public List<int>? TagIds { get; set; } = [];
}

public class UpdateProductDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
    public decimal Price { get; set; }

    public List<int>? NewTagIds { get; set; } = [];
    public List<int>? RemovedTagIds { get; set; } = [];
}

public class RemoveTagsFromProductDto
{
    public int ProductId { get; set; }
    public List<int> TagIds { get; set; } = [];
}
