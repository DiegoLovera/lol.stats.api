using lol.stats.api.Config;
using lol.stats.api.Dtos;
using Microsoft.Extensions.Options;
using System.Net.Http;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace lol.stats.api.Services
{
    public class RiotService : IRiotService
    {
        private readonly IHttpClientFactory _httpClient;
        private readonly AppSettings _appConfig;
        private readonly JsonSerializerOptions _jsonOptions;

        public RiotService(IHttpClientFactory clientFactory, IOptions<AppSettings> configuration)
        {
            _httpClient = clientFactory;
            _appConfig = configuration.Value;
            _jsonOptions = new JsonSerializerOptions();
            _jsonOptions.Converters.Add(new JsonStringEnumConverter());
            _jsonOptions.WriteIndented = true;
        }

        public async Task<MatchDetail> GetMatchDetail(string gameId)
        {
            var uri = _appConfig.BaseAddress + _appConfig.Game + gameId;
            var responseString = await _httpClient.CreateClient("riot").GetStringAsync(uri);
            return JsonSerializer.Deserialize<MatchDetail>(responseString, _jsonOptions);
        }

        public async Task<Summoner> GetSummoner(string summonerName)
        {
            var uri = _appConfig.BaseAddress + _appConfig.Summoner + summonerName;
            var responseString = await _httpClient.CreateClient("riot").GetStringAsync(uri);
            return JsonSerializer.Deserialize<Summoner>(responseString, _jsonOptions);
        }

        public async Task<SummonerMatches> GetSummonerMatches(string accountId, int queue, int season, long beginTime)
        {
            var uri = _appConfig.BaseAddress + _appConfig.SummonerMatches + accountId + "?queue=" + queue + "&season=" + season + "&beginTime=" + beginTime;
            var responseString = await _httpClient.CreateClient("riot").GetStringAsync(uri);
            return JsonSerializer.Deserialize<SummonerMatches>(responseString, _jsonOptions);
        }

        public async Task<SummonerMatches> GetSummonerMatches(string accountId, int season, long beginTime)
        {
            var uri = _appConfig.BaseAddress + _appConfig.SummonerMatches + accountId + "&season=" + season + "&beginTime=" + beginTime;
            var responseString = await _httpClient.CreateClient("riot").GetStringAsync(uri);
            return JsonSerializer.Deserialize<SummonerMatches>(responseString, _jsonOptions);
        }

        public async Task<SummonerMatches> GetSummonerMatches(string accountId, int queue, int season)
        {
            var uri = _appConfig.BaseAddress + _appConfig.SummonerMatches + accountId + "?queue=" + queue + "&season=" + season;
            var responseString = await _httpClient.CreateClient("riot").GetStringAsync(uri);
            return JsonSerializer.Deserialize<SummonerMatches>(responseString, _jsonOptions);
        }

        public async Task<SummonerMatches> GetSummonerMatches(string accountId, int season)
        {
            var uri = _appConfig.BaseAddress + _appConfig.SummonerMatches + accountId + "&season=" + season;
            var responseString = await _httpClient.CreateClient("riot").GetStringAsync(uri);
            return JsonSerializer.Deserialize<SummonerMatches>(responseString, _jsonOptions);
        }

        public async Task<SummonerMatches> GetSummonerMatches(string accountId)
        {
            var uri = _appConfig.BaseAddress + _appConfig.SummonerMatches + accountId;
            var responseString = await _httpClient.CreateClient("riot").GetStringAsync(uri);
            return JsonSerializer.Deserialize<SummonerMatches>(responseString, _jsonOptions);
        }
    }
}
