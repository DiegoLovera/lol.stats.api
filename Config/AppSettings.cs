using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lol.stats.api.Config
{
    public class AppSettings
    {
        public string BaseAddress { get; set; }
        public string ApiKey { get; set; }
        public string Summoner { get; set; }
        public string SummonerMatches { get; set; }
        public string Game { get; set; }
    }
}
