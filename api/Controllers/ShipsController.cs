

using Microsoft.AspNetCore.Mvc;
using NapaTraineeAPI.Models;
using NapaTraineeAPI.Services;

namespace NapaTraineeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ShipsController : ControllerBase
    {
        private readonly IShipsService _shipsService;

        public ShipsController(IShipsService shipsService)
        {
            _shipsService = shipsService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Ship>>> GetShips()
        {
            var ships = await _shipsService.GetAllAsync();
            return Ok(ships);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Ship>> GetShip(int id)
        {
            var ship = await _shipsService.GetByIdAsync(id);
            if (ship == null)
            {
                return NotFound();
            }
            return Ok(ship);
        }
    }
}
