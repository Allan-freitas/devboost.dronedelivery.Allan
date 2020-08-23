using devboost.dronedelivery.DTO;
using devboost.dronedelivery.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace devboost.dronedelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PedidoController : ControllerBase
    {
        readonly PedidoService _pedidoService;

        public PedidoController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] PedidoDTO pedidoDto)
        {
            try
            {
                await _pedidoService.InserirPedido(pedidoDto);
                return StatusCode(StatusCodes.Status201Created);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
