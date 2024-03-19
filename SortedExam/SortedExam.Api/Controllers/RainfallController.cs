using Microsoft.AspNetCore.Mvc;
using SortedExam.Model.App.Responses;

namespace SortedExam.Api.Controllers
{
    /// <summary>
    /// Operations relating to rainfall
    /// </summary>
    [Route("[controller]")]
    [ApiController]
    public class RainfallController : ControllerBase
    {
        /// <summary>
        /// Retrieve the latest readings for the specified stationId
        /// </summary>
        /// <param name="stationId">The id of the reading station</param>
        /// <param name="count">The number of readings to return</param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        [HttpGet("id/{stationId}/readings")]
        [ProducesResponseType(typeof(IEnumerable<RainfallReadingResponse>), StatusCodes.Status200OK)]
        public async Task<ActionResult<IEnumerable<RainfallReadingResponse>>> GetAllStationReadingAsync(string stationId, int? count = 10)
        {
            throw new NotImplementedException();
        }
    }
}
