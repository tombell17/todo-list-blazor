using System.Collections.Generic;
using System.Threading.Tasks;

namespace ToDoListBlazor.Domain.Abstractions
{
    public interface IRepository<TData>
    {
        Task<TData> Create(TData data);
        Task<TData> Update(TData data);
        Task Delete(TData data);
        Task<TData> Get(string id);
        Task<IEnumerable<TData>> GetAll();
    }
}
