namespace SortedExam.Model.App.Locals
{
    public class ErrorDetail
    {
        public string PropertyName { get; }
        public string Message { get; }

        public ErrorDetail(string propertyName, string message)
        {
            PropertyName = propertyName;
            Message = message;
        }
    }
}
