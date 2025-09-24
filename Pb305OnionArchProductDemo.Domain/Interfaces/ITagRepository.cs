using Pb305OnionArchProductDemo.Domain.Entities;

namespace Pb305OnionArchTagDemo.Domain.Interfaces;

public interface ITagRepository
{
    Task<IEnumerable<Tag>> GetAllTagsAsync();
    Task<Tag?> GetTagByIdAsync(int id);
    Task<Tag> AddTagAsync(Tag Tag);
    Task UpdateTagAsync(Tag Tag);
    Task DeleteTagAsync(int id);
}
