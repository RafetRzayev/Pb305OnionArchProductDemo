namespace Pb305OnionArchProductDemo.Application.Dtos;

public class TagDto
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class CreateTagDto
{
    public string Name { get; set; } = null!;
}

public class UpdateTagDto
{
    public int Id { get; set; }
    public string Name { get; set; } = null!;
}
