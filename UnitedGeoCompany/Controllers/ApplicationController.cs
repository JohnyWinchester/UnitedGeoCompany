using Microsoft.AspNetCore.Mvc;
using UnitedGeoCompany.Controllers.Requests;
using UnitedGeoCompany.DataTransfer.Application;
using UnitedGeoCompany.Services.Interfaces;
using UnitedGeoCompanyDataBase.Models;

namespace UnitedGeoCompany.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApplicationController : ControllerBase
    {
        private readonly ISecretaryService _secretaryService;

        public ApplicationController(
            ISecretaryService secretaryService)
        {
            _secretaryService = secretaryService;
        }

        /// <summary>
        /// Регистрация заявки.
        /// </summary>
        /// <param name="application">Заявка.</param>
        [HttpPost("[action]")]
        public async Task<ActionResult> Add([FromBody]ApplicationDto application)
        {
            await _secretaryService.AddApplication(application);
            return Ok();
        }

        /// <summary>
        /// Узнать статус заявки.
        /// </summary>
        /// <param name="id">ID заявки.</param>
        /// <returns>Статус заявки.</returns>
        [HttpGet("{id}/Status")]
        public async Task<string> GetApplicationStatusById(long id)
            => await _secretaryService.ApplicationStatus(id);



        /// <summary>
        /// Узнать статус заявки.
        /// </summary>
        /// <param name="id">ID заявки.</param>
        /// <returns>Статус заявки.</returns>
        [HttpPost("{applicationid}/Add/{brigadeId}")]
        public async Task<ActionResult> AddObjectiveToBrigadeByApplication (
            long applicationid,
            long brigadeId,
            CancellationToken cancellationToken)
        {
            if (await _secretaryService.GiveObjectiveToBrigade(applicationid, brigadeId, cancellationToken) is { } error)
                return BadRequest(error);

            return Ok();
        }

        /// <summary>
        /// Обновить статус заявки.
        /// </summary>
        /// <returns>Заявка.</returns>
        [HttpPost("/Status")]
        public async Task<ActionResult<Application>> UpdateApplicationStatus(
            [FromBody] ApplicationStatusRequest request,
            CancellationToken cancellationToken)
        {
            var result 
                = await _secretaryService.UpdateApplicationStatus(request.ApplicationId, request.Status, cancellationToken);

            if (result.Match(ok => null, error => error) is { } error)
                return BadRequest(error);

            return result.AsT0;
        }
    }
}
