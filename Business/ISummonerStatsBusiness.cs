using lol.stats.api.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lol.stats.api.Business
{
    public interface ISummonerStatsBusiness
    {
        Task<List<MatchDetail>> GetSummonerMatchesAsync(string summonerName, int page, int[] queues, int[] seasons);
    }
}
