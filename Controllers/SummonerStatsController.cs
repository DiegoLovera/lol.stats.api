using lol.stats.api.Business;
using lol.stats.api.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
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
        private readonly int[] validSeasons = { 14,13,12,11,10,9,8,7,6,5,4,3,2,1,0 };
        private readonly int[] validQueues = { 400,420,430,440 };

        public SummonerStatsController(ISummonerStatsBusiness summonerStatsBusiness)
        {
            _summonerStatsBusiness = summonerStatsBusiness;
        }

        /// <summary>
        /// Método para obtener la lista de partidas de un invocador con base en los filtros envíados.
        /// </summary>
        /// <param name="summonerName">Nombre del invocador</param>
        /// <param name="queues">Lista de juego. 400 - Normal Draft Pick, 420 - Ranked SoloQ, 430 - Normal Blind Pick, 440 - Ranked Flex</param>
        /// <param name="seasons">Temporada de juego. 14 - Season 2020, 13 - Season 2019, 12 - Pre-Season 2019......</param>
        /// <param name="page">Página de resultados. Este valor empieza de 1 en adelante, en caso de no ser envíado se tomara 1 por default.</param>
        /// <returns>Una lista con las partidas del juegador buscado.</returns>
        [HttpGet("/MatchesList/{summonerName}")]
        [ProducesResponseType(typeof(List<MatchDetail>), 200)]
        public async Task<ActionResult> GetMatchesList([Required] string summonerName, [FromQuery(Name = "seasons")] int[] seasons, [FromQuery(Name = "queues")] int[] queues = null, [FromQuery] int page = 1)
        {
            try
            {
                foreach(int season in seasons)
                {
                    if (!validSeasons.Contains(season))
                    {
                        return BadRequest("La season envíada no se encuentra dentro de las temporadas validas (0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14).");
                    }
                }

                foreach (int queue in queues)
                {
                    if (!validQueues.Contains(queue))
                    {
                        return BadRequest("La queue envíada no se encuentra dentro de las queues validas (420, 430, 440).");
                    }
                }
                if (page < 1)
                {
                    return BadRequest("La página no puede ser menor a 1.");
                }
                return Ok(await _summonerStatsBusiness.GetSummonerMatchesAsync(summonerName, page, queues, seasons));
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