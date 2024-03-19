namespace SortedExam.Model.App.Locals
{
    /// <summary>
    /// Details of a rainfall reading
    /// </summary>
    public class RainfallReading
    {
        public DateTime DateMeasured { get; }
        public decimal AmountMeasured { get; }

        public RainfallReading(DateTime dateMeasured, decimal amountMeasured)
        {
            DateMeasured = dateMeasured;
            AmountMeasured = amountMeasured;
        }
    }
}
