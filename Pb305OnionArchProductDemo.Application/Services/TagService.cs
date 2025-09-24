using Pb305OnionArchProductDemo.Application.Dtos;
using Pb305OnionArchProductDemo.Domain.Entities;
using Pb305OnionArchTagDemo.Application.Interfaces;
using Pb305OnionArchTagDemo.Domain.Interfaces;

namespace Pb305OnionArchTagDemo.Application.Services;

public class TagService : ITagService
{
    private readonly ITagRepository _tagRepository;

    public TagService(ITagRepository tagRepository)
    {
        _tagRepository = tagRepository;
    }

    public async Task<TagDto> AddTagAsync(CreateTagDto createTagDto)
    {
        var tag = new Tag
        {
            Name = createTagDto.Name,
        };

        var createdTag = await _tagRepository.AddTagAsync(tag);

        return new TagDto
        {
            Id = createdTag.Id,
            Name = createdTag.Name,
        };
    }

    public async Task DeleteTagAsync(int id)
    {
        await _tagRepository.DeleteTagAsync(id);
    }

    public async Task<IEnumerable<TagDto>> GetAllTagsAsync()
    {
        var tags = await _tagRepository.GetAllTagsAsync();

        var tagDtos = tags.Select(p => new TagDto
        {
            Id = p.Id,
            Name = p.Name,
        });

        return tagDtos;
    }

    public async Task<TagDto?> GetTagByIdAsync(int id)
    {
        var tag = await _tagRepository.GetTagByIdAsync(id);

        if (tag == null)
            return null;

        var tagDto = new TagDto
        {
            Id = tag.Id,
            Name = tag.Name,
        };

        return tagDto;
    }

    public Task UpdateTagAsync(UpdateTagDto updateTagDto)
    {
        var tag = new Tag
        {
            Id = updateTagDto.Id,
            Name = updateTagDto.Name,
        };

        return _tagRepository.UpdateTagAsync(tag);
    }
}
