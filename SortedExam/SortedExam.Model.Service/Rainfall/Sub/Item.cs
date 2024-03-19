using Newtonsoft.Json;

namespace SortedExam.Model.Service.Rainfall.Sub
{
    public class Item
    {
        [JsonProperty("@id")]
        public string id { get; set; } = null!;

        public DateTime dateTime { get; set; }

        public string measure { get; set; } = null!;

        public decimal value { get; set; }
    }
}
