using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using lol.stats.api.Business;
using lol.stats.api.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace lol.stats.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummonerStatsController : ControllerBase
    {
        private readonly ISummonerStatsBusiness _summonerStatsBusiness;
        private readonly IRiotService _riotService;

        public SummonerStatsController(ISummonerStatsBusiness summonerStatsBusiness, IRiotService riotService)
        {
            _summonerStatsBusiness = summonerStatsBusiness;
            _riotService = riotService;
        }

        [HttpGet("/{summonerName}")]
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
    }
}