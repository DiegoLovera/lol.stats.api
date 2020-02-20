using lol.stats.api.Dao;
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
        private readonly IBaseDao<MatchDetail> _matchDetailDao;
        private readonly int _maxMatchesPerRequest = 15;
        private readonly int[] validQueues = { 400, 420, 430, 440 };
        private readonly int _minGamesToBePremade = 2;

        public SummonerStatsBusiness(IRiotService riotService, IBaseDao<MatchDetail> matchDetailDao)
        {
            _riotService = riotService;
            _matchDetailDao = matchDetailDao;
        }

        public async Task<List<MatchDetail>> GetSummonerMatchesAsync(string summonerName, int page, int[] queues, int[] seasons)
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
            var matchesDetails = await GetMatchDetailsListAsync(result);
            await _matchDetailDao.InsertMany(matchesDetails);
            return matchesDetails;
        }

        private async Task<List<MatchDetail>> GetMatchDetailsListAsync(MatchesList matchesList)
        {
            var result = new List<MatchDetail>();
            foreach (Match match in matchesList.Matches)
            {
                result.Add(await _riotService.GetMatchDetail(match.GameId));
            }
            return result;
        }

        public async Task<SummonerStats> GetSummonerStatsAsync(string accountId)
        {
            var result = new SummonerStats
            {
                MatchesDetails = new List<MatchDetail>(),
                UniqueChampions = new List<UniqueChampionStats>()
            };
            var premadeCandidates = new List<Premade>();
            var matches = await _matchDetailDao.Get(accountId);
            matches.ForEach(m =>
            {
                try
                {
                    // Busco dentro de la lista de participantes el que tiene el mismo id de cuenta que el summoner buscado
                    var participant = m.ParticipantIdentities.Where(p => p.Player.CurrentAccountId == accountId).FirstOrDefault();
                    // Obtengo los stats del summoner con el id de participante encontrado en el filtro anterior
                    var participantStats = m.Participants.Where(p => p.ParticipantId == participant.ParticipantId).FirstOrDefault();

                    // Relleno los stats
                    result.Kills += participantStats.Stats.Kills;
                    result.Deaths += participantStats.Stats.Deaths;
                    result.Assists += participantStats.Stats.Assists;

                    result.MaxKills = result.MaxKills < participantStats.Stats.Kills ? participantStats.Stats.Kills : result.MaxKills;
                    result.MaxDeaths = result.MaxDeaths < participantStats.Stats.Deaths ? participantStats.Stats.Deaths : result.MaxDeaths;
                    result.MaxAssists = result.MaxAssists < participantStats.Stats.Assists ? participantStats.Stats.Assists : result.MaxAssists;

                    // Obtengo el equipo del summoner buscado
                    var team = m.Teams.Where(t => t.TeamId == participantStats.TeamId).FirstOrDefault();

                    // Determino si fue victoria o derrola para el equipo del summoner buscado
                    var wasWin = team.Win != "Fail";

                    // Aumento la victoria o derrota según corresponda
                    result.Wins += wasWin ? 1 : 0;
                    result.Losses += wasWin ? 0 : 1;

                    // Busco al campeon de esta partida dentro de la lista de campeones unicos
                    if (result.UniqueChampions.Exists(u => u.ChampionId == participantStats.ChampionId))
                    {
                        // Si ya existe aumento sus victorias o derrotas segun el resultado de la partida
                        var uniqueChamp = result.UniqueChampions.Find(p => p.ChampionId == participantStats.ChampionId);
                        uniqueChamp.Kills += participantStats.Stats.Kills;
                        uniqueChamp.Deaths += participantStats.Stats.Deaths;
                        uniqueChamp.Assists += participantStats.Stats.Assists;
                        uniqueChamp.MaxKills = uniqueChamp.MaxKills < participantStats.Stats.Kills ? participantStats.Stats.Kills : uniqueChamp.MaxKills;
                        uniqueChamp.MaxDeaths = uniqueChamp.MaxDeaths < participantStats.Stats.Deaths ? participantStats.Stats.Deaths : uniqueChamp.MaxDeaths;
                        uniqueChamp.MaxAssists = uniqueChamp.MaxAssists < participantStats.Stats.Assists ? participantStats.Stats.Assists : uniqueChamp.MaxAssists;
                        uniqueChamp.Wins += wasWin ? 1 : 0;
                        uniqueChamp.Losses += wasWin ? 0 : 1;
                    }
                    else
                    {
                        // Si no existe lo agrego y inicio sus contadores
                        result.UniqueChampions.Add(new UniqueChampionStats()
                        {
                            ChampionId = participantStats.ChampionId,
                            Kills = participantStats.Stats.Kills,
                            Deaths = participantStats.Stats.Deaths,
                            Assists = participantStats.Stats.Assists,
                            MaxKills = participantStats.Stats.Kills,
                            MaxDeaths = participantStats.Stats.Deaths,
                            MaxAssists = participantStats.Stats.Assists,
                            Wins = wasWin ? 1 : 0,
                            Losses = wasWin ? 0 : 1
                        });
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
                        if (premadeCandidates.Exists(p => p.AccountId == t.Player.CurrentAccountId))
                        {
                            // Si ya existe aumento sus victorias o derrotas segun el resultado de la partida
                            var preCandidate = premadeCandidates.Find(p => p.AccountId == t.Player.CurrentAccountId);
                            preCandidate.Wins += wasWin ? 1 : 0;
                            preCandidate.Losses += wasWin ? 0 : 1;
                        }
                        else
                        {
                            // Si no existe agrego uno nuevo
                            premadeCandidates.Add(new Premade()
                            {
                                AccountId = t.Player.CurrentAccountId,
                                SummonerName = t.Player.SummonerName,
                                Wins = wasWin ? 1 : 0,
                                Losses = wasWin ? 0 : 1
                            });
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

            premadeCandidates.RemoveAll(r => r.Games < _minGamesToBePremade || r.AccountId == accountId);
            result.Premades = premadeCandidates;
            return result;
        }
    }
}
