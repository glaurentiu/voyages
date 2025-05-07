using Microsoft.AspNetCore.Mvc;
using NapaTraineeAPI.Models;
using NapaTraineeAPI.Services;

namespace NapaTraineeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class VoyagesController : ControllerBase
    {
        private readonly IVoyagesService _voyagesService;

        public VoyagesController(IVoyagesService voyagesService)
        {
            _voyagesService = voyagesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<VoyageDto>>> GetVoyages()
        {
            var voyages = await _voyagesService.GetAllAsync();
            return Ok(voyages);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Voyage>> GetVoyage(int id)
        {
            var voyage = await _voyagesService.GetByIdAsync(id);
            if (voyage == null)
            {
                return NotFound();
            }
            return Ok(voyage);
        }
    }
}
