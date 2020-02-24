using lol.stats.api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lol.stats.api.Dao
{
    public interface IMatchDao : IBaseDao<MatchDetail>
    {
        Task<List<MatchDetail>> Get(string accountId);
        Task<List<MatchDetail>> Get(string accountId, int skip);
        Task<List<MatchDetail>> Get(string accountId, int skip, long[] queue);
    }
}
