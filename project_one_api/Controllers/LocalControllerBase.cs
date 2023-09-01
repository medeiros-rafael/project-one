using POFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace project_one_api.Controllers
{
    public class LocalControllerBase : ControllerBase
    {
        public IActionResult Result(ResponseStatus responseStatus, string message)
        {
            return new POActionResult(responseStatus, message).ToActionResult();
        }
        public IActionResult Result<T>(ResponseStatus responseStatus, T value)
        {
            return new POActionResult<T>(responseStatus, value).ToActionResult();
        }

        public IActionResult Result<T>(ResponseStatus responseStatus, T value, string message)
        {
            return new POActionResult<T>(responseStatus, value, message).ToActionResult();
        }
    }
}
