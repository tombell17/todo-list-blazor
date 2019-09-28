using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoListBlazor.Domain.Abstractions
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> Create(TEntity entity);
        Task<TEntity> Update(TEntity entity);
        Task Delete(TEntity entity);
        Task<TEntity> Get(int id);
        Task<IEnumerable<TEntity>> GetAll();
    }
}
