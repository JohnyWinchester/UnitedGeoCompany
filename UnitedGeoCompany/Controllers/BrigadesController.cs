using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UnitedGeoCompany.DataTransfer.Brigades;
using UnitedGeoCompany.DataTransfer.Filters;
using UnitedGeoCompany.Services.Interfaces;

namespace UnitedGeoCompany.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrigadesController : ControllerBase
    {
        private readonly IBrigadesService _brigadesService;
        public BrigadesController(
            IBrigadesService brigadesService)
        {
            _brigadesService = brigadesService;
        }

        [HttpPost("{Id}/Complete/{applicationId}")]
        public async Task<ActionResult> ObjectiveCompled(
            long Id,
            long applicationId,
            string notes, 
            CancellationToken cancellationToken)
        {
            await _brigadesService.CompledBrigadeObjective(Id, applicationId, notes, cancellationToken);

            return Ok("Заявка закрыта.");
        }

        [HttpGet("/Statistics")]
        public async Task<ActionResult<BrigadesStatisticDto>> GetStatistics([FromQuery] InputDateFilterDTO input, CancellationToken cancellationToken)
        {
            if (input is { BeforeMonth: null, BeforeYear: not null } or
                { BeforeMonth: not null, BeforeYear: null })
                return BadRequest("Before month and year must be specified together");

            return await _brigadesService.GetStatistic(input, cancellationToken);
        }
    }
}
