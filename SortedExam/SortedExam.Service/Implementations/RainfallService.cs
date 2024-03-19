using SortedExam.Model.App.Locals;
using SortedExam.Model.App.Responses;
using SortedExam.Model.Service.Rainfall;
using SortedExam.Service.Interfaces;
using System.Net.Http.Json;

namespace SortedExam.Service.Implementations
{
    public class RainfallService : IRainfallService
    {
        private readonly HttpClient _rainfallClient;

        public RainfallService(IHttpClientFactory httpClientFactory)
        {
            _rainfallClient = httpClientFactory.CreateClient(Constants.RAINFALL_CLIENT);
        }

        public async Task<RainfallReadingResponse> GetStationReadingAsync(string stationId, int? count = 10)
        {
            HttpResponseMessage? response = null;
            try
            {
                var stationReadingUrl = $"/flood-monitoring/id/stations/{stationId}/readings";
                if (count != null)
                    stationReadingUrl += $"?_limit={count}";
                response = await _rainfallClient.GetAsync(stationReadingUrl);
                if (response.IsSuccessStatusCode)
                {
                    var returnValue = await response.Content.ReadFromJsonAsync<StationReading>();
                    if (returnValue == null)
                        throw new Exception($"StationId does not have readings.");

                    List<RainfallReading> stations = new List<RainfallReading>();
                    returnValue.items.ForEach(item =>
                    {
                        stations.Add(new RainfallReading(item.dateTime, item.value));
                    });

                    return new RainfallReadingResponse(stations);
                }
                else
                {
                    throw new Exception($"{response.StatusCode}: Unknown error occurred");
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
