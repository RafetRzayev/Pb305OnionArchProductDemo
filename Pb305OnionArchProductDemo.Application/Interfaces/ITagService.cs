using Pb305OnionArchProductDemo.Application.Dtos;

namespace Pb305OnionArchTagDemo.Application.Interfaces;

public interface ITagService
{
    Task<IEnumerable<TagDto>> GetAllTagsAsync();
    Task<TagDto?> GetTagByIdAsync(int id);
    Task<TagDto> AddTagAsync(CreateTagDto createTagDto);
    Task UpdateTagAsync(UpdateTagDto updateTagDto);
    Task DeleteTagAsync(int id);
}
