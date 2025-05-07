using Microsoft.AspNetCore.Mvc;
using NapaTraineeAPI.Models;
using NapaTraineeAPI.Services;

namespace NapaTraineeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PortsController : ControllerBase
    {
        private readonly IPortsService _portsService;

        public PortsController(IPortsService portsService)
        {
            _portsService = portsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Port>>> GetPorts()
        {
            var ports = await _portsService.GetAllAsync();
            return Ok(ports);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Port>> GetPort(int id)
        {
            var port = await _portsService.GetByIdAsync(id);
            if (port == null)
            {
                return NotFound();
            }
            return Ok(port);
        }
    }
}
