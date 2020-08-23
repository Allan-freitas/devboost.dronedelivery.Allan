using devboost.dronedelivery.DTO;
using devboost.dronedelivery.Service;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace devboost.dronedelivery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DroneController : ControllerBase
    {
        readonly PedidoService _pedidoService;

        public DroneController(PedidoService pedidoService)
        {
            _pedidoService = pedidoService;
        }

        [HttpGet]
        public async Task<ActionResult> Get()
        {
            var result = await _pedidoService.BuscarDrone();
            return Ok(result);
        }
    }
}
