using AutoMapper;
using Pb305OnionArchProductDemo.Domain.Entities;
using Pb305OnionArchProductDemo.Application.Dtos;

namespace Pb305OnionArchProductDemo.Application.AutoMapping
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // CreateMap<Source, Destination>();
            CreateMap<CreateProductDto, Product>()
                .ForMember(dest => dest.ProductTags, opt => opt.MapFrom(src => src.TagIds != null ? src.TagIds.Select(tagId => new ProductTag
                {
                    TagId = tagId
                }).ToList() : new List<ProductTag>()))
                .ReverseMap();
            CreateMap<Product, UpdateProductDto>().ReverseMap();
            CreateMap<Product, ProductDto>()
                .ForMember(dest => dest.Tags, opt => opt.MapFrom(src => src.ProductTags != null ? src.ProductTags.Select(pt => new TagDto
                {
                    Id = pt.Tag == null ? 0 : pt.Tag.Id,
                    Name = pt.Tag == null ? string.Empty : pt.Tag.Name
                }).ToList() : new List<TagDto>()))
                .ReverseMap();

            CreateMap<Tag, TagDto>().ReverseMap();
            CreateMap<Tag, CreateTagDto>().ReverseMap();
            CreateMap<Tag, UpdateTagDto>().ReverseMap();
        }
    }
}
