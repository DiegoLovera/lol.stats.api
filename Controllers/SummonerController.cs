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
    [Route("api/Summoner")]
    [ApiController]
    public class SummonerController : ControllerBase
    {
        private readonly ISummonerStatsBusiness _summonerStatsBusiness;
        private readonly int[] validSeasons = { 14,13,12,11,10,9,8,7,6,5,4,3,2,1,0 };
        private readonly int[] validQueues = { 400,420,430,440 };

        public SummonerController(ISummonerStatsBusiness summonerStatsBusiness)
        {
            _summonerStatsBusiness = summonerStatsBusiness;
        }

        /// <summary>
        /// Método para obtener la stats y partidas de un invocador con base en los filtros envíados.
        /// </summary>
        /// <param name="summonerName">Nombre del invocador</param>
        /// <param name="queues">Lista de juego. 400 - Normal Draft Pick, 420 - Ranked SoloQ, 430 - Normal Blind Pick, 440 - Ranked Flex</param>
        /// <param name="page">Página de resultados. Este valor empieza de 1 en adelante, en caso de no ser envíado se tomara 0 por default.</param>
        /// <returns>Una lista con las partidas del juegador buscado.</returns>
        [HttpGet("{summonerName}/Matches")]
        [ProducesResponseType(typeof(List<SummonerMatch>), 200)]
        [ProducesResponseType(typeof(string), 404)]
        [ProducesResponseType(typeof(string), 400)]
        [ProducesResponseType(typeof(string), 500)]
        public async Task<ActionResult> GetSummonerMatches([Required] string summonerName, [FromQuery(Name = "queues")] long[] queues = null, [FromQuery] int page = 0)
        {
            try
            {
                foreach (int queue in queues)
                {
                    if (!validQueues.Contains(queue))
                    {
                        return BadRequest("La queue envíada no se encuentra dentro de las queues validas (420, 430, 440).");
                    }
                }

                if (page < 0)
                {
                    return BadRequest("La página no puede ser menor a 0.");
                }

                var matches = await _summonerStatsBusiness.GetSummonerMatchesAsync(summonerName, page, queues);
                if (matches.Count > 0)
                {
                    return Ok(matches);
                }
                else
                {
                    return NotFound("No se encuentran partidas en la página envíada.");
                }
                
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{summonerName}/Stats")]
        [ProducesResponseType(typeof(SummonerStats), 200)]
        public async Task<ActionResult> GetSummonerStats([Required] string summonerName)
        {
            try
            {
                return Ok(await _summonerStatsBusiness.GetSummonerStatsAsync(summonerName));
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }

        [HttpGet("{summonerName}/Matches/LoadAll")]
        [ProducesResponseType(typeof(bool), 200)]
        public async Task<ActionResult> LoadAllSummonerMatches([Required] string summonerName)
        {
            try
            {
                int[] validQueues = { 420, 440 };
                return Ok(await _summonerStatsBusiness.LoadAllSummonerMatches(summonerName, validQueues));
            }
            catch (HttpRequestException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
    }
}