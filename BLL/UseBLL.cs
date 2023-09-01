using BLL.Exceptions;
using DAL;
using DTO;

namespace BLL
{
    public class UserBLL
    {
        private readonly UserDAL userDAL;

        public UserBLL()
        {
            this.userDAL = new UserDAL();
        }

        public List<UserDTO> Get(UserDTO dto)
        {
            List<UserDTO> users = userDAL.Get(dto);

            return users;
        }

        public UserDTO Authentication(UserDTO dto)
        {
            UserDTO user = new UserDTO();

            if (POFrameWork.Functions.ValidateEmailFormat(dto.Login))
            {
                user = userDAL.Search(new UserDTO { Email = dto.Login });
            }
            else
            {
                user = userDAL.Search(new UserDTO { UserLogin = dto.Login });
            }

            if (user != null)
            {
                dto.Password = POFrameWork.Crypto.EncryptMd5Hash(dto.Password);

                if (dto.Password.Equals(user.Password))
                    return user;
                else
                    throw new InvalidUserOrPasswordException();
            }
            else
            {
                throw new InvalidUserOrPasswordException();
            }
        }
    }
}
