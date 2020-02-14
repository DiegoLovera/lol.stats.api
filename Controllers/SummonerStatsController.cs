using lol.stats.api.Business;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace lol.stats.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummonerStatsController : ControllerBase
    {
        private readonly ISummonerStatsBusiness _summonerStatsBusiness;

        public SummonerStatsController(ISummonerStatsBusiness summonerStatsBusiness)
        {
            _summonerStatsBusiness = summonerStatsBusiness;
        }
        
        [HttpGet("/SummonerMatches/{summonerName}")]
        public async Task<ActionResult> GetSummonerMatches([Required] string summonerName, [FromQuery(Name = "queues")] int[] queues, [FromQuery(Name = "seasons")] int[] seasons)
        {
            int[] validSeasons = { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            int[] validQueues = { 420, 430, 440 };
            try
            {
                foreach(int season in seasons)
                {
                    if (!validSeasons.Contains(season))
                    {
                        return BadRequest("La season envíada no se encuentra dentro de las temporadas validas (0,1,2,3,4,5,6,7,8,9,10,11,12,13,14).");
                    }
                }

                foreach (int queue in queues)
                {
                    if (!validQueues.Contains(queue))
                    {
                        return BadRequest("La queue envíada no se encuentra dentro de las queues validas (420,430,440).");
                    }
                }
                return Ok(await _summonerStatsBusiness.GetSummonerMatchesAsync(summonerName, queues, seasons));
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