using lol.stats.api.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lol.stats.api.Dao
{
    public interface ISummonerMatchesControlDao
    {
        Task<List<SummonerMatchesControl>> Get();
        Task<SummonerMatchesControl> GetById(string Id);
        Task<List<SummonerMatchesControl>> GetByAccountId(string accountId);
        Task<SummonerMatchesControl> GetByAccountIdAndQueue(string accountId, int queue);
        Task<SummonerMatchesControl> Create(SummonerMatchesControl document);
        Task Update(string id, SummonerMatchesControl document);
        Task Remove(SummonerMatchesControl document);
        Task Remove(string id);
    }
}
