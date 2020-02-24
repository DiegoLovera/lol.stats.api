using lol.stats.api.Dtos;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace lol.stats.api.Dao
{
    public interface ISummonerMatchesControlDao : IBaseDao<SummonerMatchesControl>
    {
        Task<SummonerMatchesControl> GetById(string Id);
        Task<List<SummonerMatchesControl>> GetByAccountId(string accountId);
        Task<SummonerMatchesControl> GetByAccountIdAndQueue(string accountId, int queue);
        Task Update(string id, SummonerMatchesControl document);
    }
}
