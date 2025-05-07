using Microsoft.AspNetCore.Mvc;
using NapaTraineeAPI.Models;
using NapaTraineeAPI.Services;

namespace NapaTraineeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CountriesController : ControllerBase
    {
        private readonly ICountriesService _countriesService;

        public CountriesController(ICountriesService countriesService)
        {
            _countriesService = countriesService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> GetCountries()
        {
            var countries = await _countriesService.GetAllAsync();
            return Ok(countries);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCountry(int id)
        {
            var country = await _countriesService.GetByIdAsync(id);
            if (country == null)
            {
                return NotFound();
            }
            return Ok(country);
        }
    }
}
