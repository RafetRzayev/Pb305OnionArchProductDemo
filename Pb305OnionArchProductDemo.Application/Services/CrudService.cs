using AutoMapper;
using Pb305OnionArchProductDemo.Application.Interfaces;
using Pb305OnionArchProductDemo.Domain.Entities;
using Pb305OnionArchProductDemo.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pb305OnionArchProductDemo.Application.Services
{
    public class CrudService<TDto, TCreateDto, TUpdateDto, TEntity> : ICrudService<TDto, TCreateDto, TUpdateDto, TEntity>
        where TEntity : Entity
    {
        protected readonly IRepository<TEntity> Repository;
        protected readonly IMapper Mapper;
      
        public CrudService(IRepository<TEntity> repository, IMapper mapper)
        {
            Repository = repository;
            Mapper = mapper;
        }

        public async Task<TDto> AddAsync(TCreateDto createDto)
        {
            var entity = Mapper.Map<TEntity>(createDto);

            var createdEntity = await Repository.AddAsync(entity);

            var dto = Mapper.Map<TDto>(createdEntity);

            return dto;
        }

        public async Task DeleteAsync(int id)
        {
            await Repository.DeleteAsync(id);
        }

        public virtual async Task<IEnumerable<TDto>> GetAllAsync()
        {
            var entities = await Repository.GetAllAsync();
            var dtos = Mapper.Map<IEnumerable<TDto>>(entities);

            return dtos;
        }

        public async Task<TDto?> GetByIdAsync(int id)
        {
            var entity = await Repository.GetByIdAsync(id);

            var dto = Mapper.Map<TDto>(entity);

            return dto;
        }

        public virtual async Task UpdateAsync(TUpdateDto updateDto)
        {
            var entity = Mapper.Map<TEntity>(updateDto);

            await Repository.UpdateAsync(entity);
        }
    }
}
