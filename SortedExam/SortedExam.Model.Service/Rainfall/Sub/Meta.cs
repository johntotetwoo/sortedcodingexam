namespace SortedExam.Model.Service.Rainfall.Sub
{
    public class Meta
    {
        public string publisher { get; set; } = null!;

        public string licence { get; set; } = null!;

        public string documentation { get; set; } = null!;

        public string version { get; set; } = null!;

        public string comment { get; set; } = null!;

        public List<string> hasFormat { get; set; } = new List<string>();

        public int limit { get; set; }
    }
}
