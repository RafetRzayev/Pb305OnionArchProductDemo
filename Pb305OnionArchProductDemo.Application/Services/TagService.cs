using AutoMapper;
using Pb305OnionArchProductDemo.Application.Dtos;
using Pb305OnionArchProductDemo.Application.Services;
using Pb305OnionArchProductDemo.Domain.Entities;
using Pb305OnionArchProductDemo.Domain.Interfaces;
using Pb305OnionArchTagDemo.Application.Interfaces;
using Pb305OnionArchTagDemo.Domain.Interfaces;

namespace Pb305OnionArchTagDemo.Application.Services;

public class TagService : CrudService<TagDto, CreateTagDto, UpdateTagDto, Tag>, ITagService
{
    private readonly ITagRepository _tagRepository;

    public TagService(IRepository<Tag> repository, IMapper mapper, ITagRepository tagRepository) : base(repository, mapper)
    {
        _tagRepository = tagRepository;
    }

    public async override Task UpdateAsync(UpdateTagDto updateDto)
    {
        var existingTag = await _tagRepository.GetByIdAsync(updateDto.Id);

        if (existingTag == null)
        {
            throw new KeyNotFoundException($"Tag with ID {updateDto.Id} not found.");
        }

        existingTag = Mapper.Map(updateDto, existingTag);
        //existingTag = Mapper.Map<Tag>(updateDto); exception will be thrown because same id tracking entity is already being tracked
        await _tagRepository.UpdateAsync(existingTag);
    }
}
