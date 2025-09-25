using Pb305OnionArchProductDemo.Application.Dtos;
using Pb305OnionArchProductDemo.Application.Interfaces;
using Pb305OnionArchProductDemo.Domain.Entities;

namespace Pb305OnionArchTagDemo.Application.Interfaces;

public interface ITagService : ICrudService<TagDto, CreateTagDto, UpdateTagDto, Tag>
{
    
}