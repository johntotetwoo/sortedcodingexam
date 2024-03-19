using Microsoft.AspNetCore.Mvc;
using SortedExam.Model.App.Exceptions;
using SortedExam.Model.App.Locals;
using SortedExam.Model.App.Responses;
using SortedExam.Service.Interfaces;
using SortedExam.Service.Validations;
using Swashbuckle.AspNetCore.Annotations;

namespace SortedExam.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [SwaggerTag("Operations relating to rainfall")]
    public class RainfallController : ControllerBase
    {
        private readonly IRainfallService _rainfallService;

        /// <summary>
        /// Rainfall Controller
        /// </summary>
        /// <param name="rainfallService">Rainfall Service</param>
        /// <exception cref="ArgumentNullException"></exception>
        public RainfallController(IRainfallService rainfallService)
        {
            _rainfallService = rainfallService ?? throw new ArgumentNullException(nameof(rainfallService));
        }

        [SwaggerOperation(Summary = "Get rainfall readings by station Id", Description = "Retrieve the latest readings for the specified stationId", Tags = new[] { "Rainfall" })]
        [SwaggerResponse(200, "OK", typeof(RainfallReadingResponse), Description = "A list of rainfall readings successfully retrieved")]
        [SwaggerResponse(400, "BadRequest", typeof(ErrorResponse), Description = "Invalid request")]
        [SwaggerResponse(404, "NotFound", typeof(ErrorResponse), Description = "No readings found for the specified stationId")]
        [SwaggerResponse(500, "InternalServerError", typeof(ErrorResponse), Description = "Internal server error")]
        [Produces("application/json")]
        [HttpGet("id/{stationId}/readings")]
        public async Task<IActionResult> GetAllStationReadingAsync(
            [SwaggerParameter("The id of the reading station")]
            string stationId,
            [SwaggerParameter("The number of readings to return")]
            [CountRange(1, 100)]
            int count = 10)
        {
            if (!ModelState.IsValid)
            {
                var errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage));
                return BadRequest(new ErrorResponse("Validation Error", Enumerable.Empty<ErrorDetail>()));
            }

            try
            {
                return Ok(await _rainfallService.GetStationReadingAsync(stationId, count));
            }
            catch (Exception ex)
            {
                if (ex is NoRecordFoundException)
                    return NotFound(new ErrorResponse(ex.Message, Enumerable.Empty<ErrorDetail>()));

                return StatusCode(500, new ErrorResponse(ex.Message, Enumerable.Empty<ErrorDetail>()));
            }
        }
    }
}
