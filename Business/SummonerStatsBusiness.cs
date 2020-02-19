using lol.stats.api.Dtos;
using lol.stats.api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace lol.stats.api.Business
{
    public class SummonerStatsBusiness : ISummonerStatsBusiness
    {
        private readonly IRiotService _riotService;
        private readonly int _maxMatchesPerRequest = 15;
        private readonly int[] validQueues = { 400, 420, 430, 440 };
        private readonly int _minGamesToBePremade = 2;

        public SummonerStatsBusiness(IRiotService riotService)
        {
            _riotService = riotService;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="summonerName"></param>
        /// <param name="page"></param>
        /// <param name="queues"></param>
        /// <param name="seasons"></param>
        /// <returns></returns>
        public async Task<SummonerStats> GetSummonerStatsAsync(string summonerName, int page, int[] queues, int[] seasons)
        {
            // In case of not sending any queue all valid queues are used.
            queues = (queues.Length == 0 ? validQueues : queues);

            var summonerData = await _riotService.GetSummoner(summonerName);
            int beginIndex = page;
            int endIndex = page * _maxMatchesPerRequest;
            if (beginIndex == 1)
            {
                endIndex = _maxMatchesPerRequest;
                beginIndex = 0;
            }
            else
            {
                endIndex = page * _maxMatchesPerRequest;
                beginIndex = endIndex - _maxMatchesPerRequest;
            }

            var result = new MatchesList
            {
                Matches = new List<Match>()
            };
            foreach (int queue in queues)
            {
                if (seasons.Length > 0)
                {
                    foreach (int season in seasons)
                    {
                        MatchesList summonerMatches;
                        if (season == 14)
                        {
                            summonerMatches = await _riotService.GetSummonerMatches(summonerData.AccountId, queue, 13, 1578668400000, beginIndex, endIndex);
                        }
                        else
                        {
                            summonerMatches = await _riotService.GetSummonerMatches(summonerData.AccountId, queue, season, beginIndex, endIndex);
                        }
                        result.Matches.AddRange(summonerMatches.Matches);
                        result.TotalGames += summonerMatches.TotalGames;
                    }
                }
                else
                {
                    MatchesList summonerMatches = await _riotService.GetSummonerMatches(queue, summonerData.AccountId, beginIndex, endIndex);
                    result.Matches.AddRange(summonerMatches.Matches);
                    result.TotalGames += summonerMatches.TotalGames;
                }
            }
            result.Matches = new List<Match>(result.Matches.OrderByDescending(c => c.Timestamp));
            var matches = await GetMatchDetailsListAsync(result);
            return GetAdvancedStats(summonerData, matches);
        }

        private async Task<List<MatchDetail>> GetMatchDetailsListAsync(MatchesList matchesList)
        {
            var result = new List<MatchDetail>();
            long matchId = 0L;
            try
            {
                foreach (Match match in matchesList.Matches)
                {
                    matchId = match.GameId;
                    result.Add(await _riotService.GetMatchDetail(match.GameId));
                }
            }
            catch (Exception)
            {
                throw new Exception("Error al obtener la información para la partida " + matchId);
            }
            return result;
        }

        private SummonerStats GetAdvancedStats(Summoner summoner, List<MatchDetail> matches)
        {
            var result = new SummonerStats
            {
                MatchesDetails = matches,
                UniqueChampions = new List<long>()
            };
            var summonerId = summoner.AccountId;
            var premadeCandidates = new List<Premade>();

            matches.ForEach(m =>
            {
                try
                {
                    var participant = m.ParticipantIdentities.Where(p => p.Player.CurrentAccountId == summonerId).FirstOrDefault();
                    var participantStats = m.Participants.Where(p => p.ParticipantId == participant.ParticipantId).FirstOrDefault();

                    result.Kills += participantStats.Stats.Kills;
                    result.Deaths += participantStats.Stats.Deaths;
                    result.Assists += participantStats.Stats.Assists;

                    result.MaxKills = result.MaxKills < participantStats.Stats.Kills ? participantStats.Stats.Kills : result.MaxKills;
                    result.MaxDeaths = result.MaxDeaths < participantStats.Stats.Deaths ? participantStats.Stats.Deaths : result.MaxDeaths;
                    result.MaxAssists = result.MaxAssists < participantStats.Stats.Assists ? participantStats.Stats.Assists : result.MaxAssists;

                    if (!result.UniqueChampions.Exists(c => c == participantStats.ChampionId))
                    {
                        result.UniqueChampions.Add(participantStats.ChampionId);
                    }

                    // Obtengo el equipo del summoner buscado
                    var team = m.Teams.Where(t => t.TeamId == participantStats.TeamId).FirstOrDefault();

                    // Determino si fue victoria o derrola para el summoner buscado
                    var wasWin = team.Win != "Fail";

                    // Aumento la victoria o derrota según corresponda
                    if (wasWin)
                    {
                        result.Wins++;
                    }
                    else
                    {
                        result.Losses++;
                    }

                    // Busco todos los participantes que esten en el mismo equipo del summoner buscado
                    var teamMates = m.Participants.Where(p => p.TeamId == participantStats.TeamId);

                    // Busco los identities de cada uno de los compañeros de equipo
                    var teamMatesIdentities = new List<ParticipantIdentity>();
                    foreach (Participant teamMate in teamMates)
                    {
                        // Agrego a una lista de compañeros
                        teamMatesIdentities.Add(m.ParticipantIdentities.Where(p => p.ParticipantId == teamMate.ParticipantId).FirstOrDefault());
                    }

                    // Itero a los compañeros para argegarlos a la lista o actualizar sus datos
                    teamMatesIdentities.ForEach(t =>
                    {
                        // validar si existe ya dentro de la lista
                        if (premadeCandidates.Exists(p => p.SummonerName == t.Player.SummonerName))
                        {
                            // Si ya existe aumento sus victorias o derrotas segun el resultado de la partida
                            if (wasWin)
                            {
                                premadeCandidates.Find(p => p.SummonerName == t.Player.SummonerName).Wins++;
                            }
                            else
                            {
                                premadeCandidates.Find(p => p.SummonerName == t.Player.SummonerName).Losses++;
                            }
                        }
                        else
                        {
                            // Si no existe lo agrego y inicio sus contadores
                            if (wasWin)
                            {
                                premadeCandidates.Add(new Premade() { SummonerName = t.Player.SummonerName, Wins = 1, Losses = 0 });
                            }
                            else
                            {
                                premadeCandidates.Add(new Premade() { SummonerName = t.Player.SummonerName, Wins = 0, Losses = 1 });
                            }
                        }
                    });

                    // Segun la linea y el rol se agrega la victoria o la derrota
                    switch (participantStats.Timeline.Lane)
                    {
                        case Lane.MID:
                            if (wasWin)
                            {
                                result.MidlaneCarryWins++;
                            }
                            else
                            {
                                result.MidlaneCarryLosses++;
                            }
                            break;
                        case Lane.MIDDLE:
                            if (wasWin)
                            {
                                result.MidlaneCarryWins++;
                            }
                            else
                            {
                                result.MidlaneCarryLosses++;
                            }
                            break;
                        case Lane.TOP:
                            if (wasWin)
                            {
                                result.TopCarryWins++;
                            }
                            else
                            {
                                result.TopCarryLosses++;
                            }
                            break;
                        case Lane.JUNGLE:
                            if (wasWin)
                            {
                                result.JungleWins++;
                            }
                            else
                            {
                                result.JungleLosses++;
                            }
                            break;
                        case Lane.BOT:
                            if (participantStats.Timeline.Role == Role.DUO || participantStats.Timeline.Role == Role.DUO_CARRY)
                            {
                                if (wasWin)
                                {
                                    result.BottomCarryWins++;
                                }
                                else
                                {
                                    result.BottomCarryLosses++;
                                }
                            }
                            else
                            {
                                if (wasWin)
                                {
                                    result.BottomSupportWins++;
                                }
                                else
                                {
                                    result.BottomSupportLosses++;
                                }
                            }
                            break;
                        case Lane.BOTTOM:
                            if (participantStats.Timeline.Role == Role.DUO || participantStats.Timeline.Role == Role.DUO_CARRY)
                            {
                                if (wasWin)
                                {
                                    result.BottomCarryWins++;
                                }
                                else
                                {
                                    result.BottomCarryLosses++;
                                }
                            }
                            else
                            {
                                if (wasWin)
                                {
                                    result.BottomSupportWins++;
                                }
                                else
                                {
                                    result.BottomSupportLosses++;
                                }
                            }
                            break;
                        case Lane.NONE:
                            if (wasWin)
                            {
                                result.JungleWins++;
                            }
                            else
                            {
                                result.JungleLosses++;
                            }
                            break;
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception("Error iterando la partida: " + m.GameId + " con el mensaje:" + ex.Message + " ruta: " + ex.StackTrace);
                }
                
            });

            premadeCandidates.RemoveAll(r => r.Games < _minGamesToBePremade || r.SummonerName == summoner.Name);
            result.Premades = premadeCandidates;

            result.KillsByChampions = new Dictionary<string, long>();
            result.DeathsByChampions = new Dictionary<string, long>();
            result.AssistsByChampions = new Dictionary<string, long>();
            result.KdaByChampions = new Dictionary<string, double>();
            return result;
        } 
    }
}
