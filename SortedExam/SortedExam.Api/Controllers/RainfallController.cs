using Microsoft.AspNetCore.Mvc;
using SortedExam.Model.App.Responses;
using SortedExam.Service.Interfaces;
using Swashbuckle.AspNetCore.Annotations;

namespace SortedExam.Api.Controllers
{
    /// <summary>
    /// Operations relating to rainfall
    /// </summary>
    [Route("[controller]")]
    [ApiController]
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
            int? count = 10)
        {
            return Ok(await _rainfallService.GetStationReadingAsync(stationId, count));
        }
    }
}
