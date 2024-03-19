using Newtonsoft.Json;
using SortedExam.Model.Service.Rainfall.Sub;

namespace SortedExam.Model.Service.Rainfall
{
    public class StationReading
    {
        [JsonProperty("@context")]
        public string context { get; set; } = null!;

        public Meta meta { get; set; } = new Meta();

        public List<Item> items { get; set; } = new List<Item>();
    }
}
