using SortedExam.Model.App.Locals;

namespace SortedExam.Model.App.Responses
{
    public class ErrorResponse
    {
        public string Message { get; } 
        public IEnumerable<ErrorDetail> Detail { get;  }

        public ErrorResponse(string message, IEnumerable<ErrorDetail> detail)
        {
            Message = message;
            Detail = detail;
        }
    }
}
