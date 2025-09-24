using Microsoft.EntityFrameworkCore;
using Pb305OnionArchTagDemo.Domain.Interfaces;
using Pb305OnionArchProductDemo.Domain.Entities;
using Pb305OnionArchProductDemo.Infrastructure.DataContext;

namespace Pb305OnionArchTagDemo.Infrastructure.Repositories;

public class TagRepository : ITagRepository
{
    private readonly AppDbContext _dbContext;

    public TagRepository(AppDbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public async Task<Tag> AddTagAsync(Tag tag)
    {
        var entityEntry = await _dbContext.Tags.AddAsync(tag);
        await _dbContext.SaveChangesAsync();

        return entityEntry.Entity;
    }

    public async Task DeleteTagAsync(int id)
    {
        var tag = _dbContext.Tags.Find(id);

        if (tag != null)
        {
            _dbContext.Tags.Remove(tag);
            await _dbContext.SaveChangesAsync();

            return;
        }

        throw new Exception($"Tag not found, with given id  : {id}");
    }

    public async Task<IEnumerable<Tag>> GetAllTagsAsync()
    {
        var tags = await _dbContext.Tags.ToListAsync();

        return tags;
    }

    public async Task<Tag?> GetTagByIdAsync(int id)
    {
        var tag = await _dbContext.Tags.FindAsync(id);

        return tag;
    }

    public async Task UpdateTagAsync(Tag tag)
    {
        var existingTag = await _dbContext
            .Tags
            .AsNoTracking()
            .FirstOrDefaultAsync(x => x.Id == tag.Id);

        if (existingTag == null)
            throw new Exception($"Tag not found, with given id  : {tag.Id}");

        _dbContext.Tags.Update(tag);
        await _dbContext.SaveChangesAsync();
    }
}
