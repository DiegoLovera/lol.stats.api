using lol.stats.api.Dtos;
using lol.stats.api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace lol.stats.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RiotController : ControllerBase
    {
        private readonly IRiotService _riotService;

        public RiotController(IRiotService riotService)
        {
            _riotService = riotService;
        }

        [HttpGet("/{summonerName}")]
        [ProducesResponseType(typeof(Summoner), 200)]
        public async Task<ActionResult> GetSummoner(string summonerName)
        {
            try
            {
                return Ok(await _riotService.GetSummoner(summonerName));
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("/Matches/{accountId}")]
        [ProducesResponseType(typeof(MatchesList), 200)]
        public async Task<ActionResult> GetMatches(string accountId, [FromQuery] int queue = 420, [FromQuery] int season = 13, [FromQuery] long beginTime = 1578668400000)
        {
            try
            {
                return Ok(await _riotService.GetSummonerMatches(accountId, queue, season, beginTime));
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }

        [HttpGet("/Match/{gameId}")]
        [ProducesResponseType(typeof(MatchDetail), 200)]
        public async Task<ActionResult> GetMatchDetail(string gameId)
        {
            try
            {
                return Ok(await _riotService.GetMatchDetail(gameId));
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(ex);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex);
            }
        }
    }
}