using devboost.dronedelivery.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace devboost.dronedelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RotinaController : ControllerBase
    {
        readonly RotinaService _rotinaService;

        public RotinaController(RotinaService rotinaService)
        {
            _rotinaService = rotinaService;
        }

        /// <summary>
        /// Rotina a ser chamada por um algo Servless
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> EnviarPedidos()
        {
            try
            {
                await _rotinaService.EnviarPedidos();
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
