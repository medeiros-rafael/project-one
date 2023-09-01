using project_one_api.Localize;
using BLL;
using BLL.Exceptions;
using DTO;
using POFrameWork;
using Microsoft.AspNetCore.Mvc;

namespace project_one_api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserController : LocalControllerBase
    {
        private UserBLL userBLL;

        public UserController()
        {
            this.userBLL = new UserBLL();
        }

        [HttpGet]
        public IEnumerable<UserDTO> Get()
        {
            List<UserDTO> users = userBLL.Get(new UserDTO { });

            return users;
        }

        [HttpPost("authentication")]
        public async Task<IActionResult> Authentication([FromBody] UserDTO dto)
        {
            try
            {
                UserDTO data = userBLL.Authentication(dto);

                return Result(ResponseStatus.Success, data);
            }
            catch (InvalidUserOrPasswordException)
            {
                return Result(ResponseStatus.Error, Resource.InvalidUserOrPassword);
            }
            catch (Exception ex)
            {
                return Result(ResponseStatus.Error, string.Format(Resource.UnexpectedError, ex.Message));
            }
        }
    }
}