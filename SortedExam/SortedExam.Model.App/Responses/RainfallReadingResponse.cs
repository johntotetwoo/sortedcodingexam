using SortedExam.Model.App.Locals;

namespace SortedExam.Model.App.Responses
{
    public class RainfallReadingResponse
    {
        public IEnumerable<RainfallReading> Readings { get; } = Enumerable.Empty<RainfallReading>();

        public RainfallReadingResponse(IEnumerable<RainfallReading> readings)
        {
            Readings = readings;
        }
    }
}
