using SortedExam.Model.App.Responses;

namespace SortedExam.Service.Interfaces
{
    public interface IRainfallService
    {
        Task<RainfallReadingResponse> GetStationReadingAsync(string stationId, int? count = 10);
    }
}
