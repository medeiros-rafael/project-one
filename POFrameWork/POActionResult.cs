using Microsoft.AspNetCore.Mvc;

namespace POFrameWork
{
    public class POActionResult<T>
    {
        public ResponseStatus Status { get; set; }
        public T Value { get; set; }
        public string Message { get; set; }

        public POActionResult(ResponseStatus status, T value)
        {
            Status = status;
            Value = value;
        }

        public POActionResult(ResponseStatus status, T value, string message)
        {
            Status = status;
            Value = value;
            Message = message;
        }

        public ActionResult ToActionResult()
        {
            return new OkObjectResult(this);
        }
    }

    public class POActionResult
    {
        public ResponseStatus Status { get; set; }
        public string Message { get; set; }

        public POActionResult(ResponseStatus status, string message)
        {
            Status = status;
            Message = message;
        }

        public ActionResult ToActionResult()
        {
            return new OkObjectResult(this);
        }
    }

    public enum ResponseStatus
    {
        Error,
        Success
    }
}
