namespace SortedExam.Model.App.Exceptions
{
    public class UnsuccessfulRequestException : Exception
    {
        public UnsuccessfulRequestException(string? message) : base(message)
        {
        }
    }
}
