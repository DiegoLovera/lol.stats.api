using System.Collections.Generic;
using System.Threading.Tasks;

namespace lol.stats.api.Dao
{
    public interface IBaseDao<T, Y>
    {
        Task<List<T>> Get();
        Task<T> Get(Y id);
        Task<T> Create(T document);
        Task InsertMany(List<T> documents);
        Task Update(Y id, T document);
        Task Remove(T document);
        Task Remove(Y id);
    }
}
