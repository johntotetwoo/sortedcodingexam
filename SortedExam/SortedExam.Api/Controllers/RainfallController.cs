using Microsoft.AspNetCore.Mvc;
using SortedExam.Model.App.Responses;
using SortedExam.Service.Interfaces;

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

        /// <summary>
        /// Retrieve the latest readings for the specified stationId
        /// </summary>
        /// <param name="stationId">The id of the reading station</param>
        /// <param name="count">The number of readings to return</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("id/{stationId}/readings")]
        [ProducesResponseType(typeof(RainfallReadingResponse), StatusCodes.Status200OK)]
        public async Task<ActionResult<RainfallReadingResponse>> GetAllStationReadingAsync(string stationId, int? count = 10)
        {
            return Ok(await _rainfallService.GetStationReadingAsync(stationId, count));
        }
    }
}
