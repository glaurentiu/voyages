using Microsoft.AspNetCore.Mvc;
using NapaTraineeAPI.Services;

namespace NapaTraineeAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ReportsController : ControllerBase
    {
        private readonly IReportsService _reportsService;

        public ReportsController(IReportsService reportsService)
        {
            _reportsService = reportsService;
        }

        [HttpGet("visited-countries-last-year")]
        public async Task<ActionResult<IEnumerable<string>>> GetVisitedCountriesLastYear()
        {
            var countries = await _reportsService.GetVisitedCountriesLastYearAsync();
            return Ok(countries);
        }
    }
}
