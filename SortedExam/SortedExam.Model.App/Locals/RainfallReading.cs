namespace SortedExam.Model.App.Locals
{
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
