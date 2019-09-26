using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using ToDoListBlazor.Domain.Abstractions;

namespace ToDoListBlazor.Infrastructure.Repositories
{
    public class EFRepository<TData> : IRepository<TData> where TData : class
    {
        private readonly EFDbContext _dbContext;        

        public EFRepository(EFDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TData> Create(TData data)
        {
            await _dbContext.Set<TData>().AddAsync(data);
            await _dbContext.SaveChangesAsync();
            return data;
        }

        public async Task Delete(TData data)
        {
            throw new NotImplementedException();
        }

        public async Task<TData> Get(string id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<TData>> GetAll()
        {
            return await _dbContext.Set<TData>()
                                   .ToListAsync();            
        }

        public async Task<TData> Update(TData data)
        {
            throw new NotImplementedException();
        }
    }
}
