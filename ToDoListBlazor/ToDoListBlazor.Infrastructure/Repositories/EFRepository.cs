using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListBlazor.Domain.Abstractions;
using ToDoListBlazor.Domain.Exceptions;
using ToDoListBlazor.Domain.Shared.Abstractions;

namespace ToDoListBlazor.Infrastructure.Repositories
{
    public class EFRepository<TEntity> : IRepository<TEntity> where TEntity : class, IEntity
    {
        private readonly EFDbContext _dbContext;        

        public EFRepository(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TEntity> Create(TEntity entity)
        {
            await _dbContext.Set<TEntity>().AddAsync(entity);
            await _dbContext.SaveChangesAsync();
            
            return entity;
        }

        public async Task Delete(TEntity entity)
        {
            var dbEntity = await Get(entity.Id);
            _dbContext.Set<TEntity>().Remove(dbEntity);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<TEntity> Get(int id)
        {
            var entity = await _dbContext.Set<TEntity>()
                                         .AsNoTracking()
                                         .FirstOrDefaultAsync(e => e.Id == id);
            ValidateFoundEntity(entity);

            return entity;
        }

        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _dbContext.Set<TEntity>()
                                   .ToListAsync();            
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _dbContext.Set<TEntity>().Update(entity);
            await _dbContext.SaveChangesAsync();
            return entity;            
        }

        private void ValidateFoundEntity(TEntity entity)
        {
            if (entity == null)
            {
                throw new EntityNotFoundException();
            }
        }
    }
}
