using System.Collections.Generic;
using System.Threading.Tasks;

namespace lol.stats.api.Dao
{
    public interface IBaseDao<T>
    {
        Task<List<T>> Get();
        Task<T> Get(long id);
        Task<T> Create(T document);
        Task InsertMany(List<T> documents);
        Task Update(long id, T document);
        Task Remove(T document);
        Task Remove(long id);
    }
}
