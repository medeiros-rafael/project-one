using DTO;
using project_one_api.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class UserDAL : Base<UserModel, UserDTO>, DALBase<UserDTO>
    {
        private ProjectOneDbContext dbContext;
        public UserDAL()
        {
            this.dbContext = new ProjectOneDbContext();
        }

        public List<UserDTO> Get(UserDTO dto)
        {
            List<UserDTO> users = ConvertClass(dbContext.Users.ToList());



            return users;
        }

        public UserDTO Search(UserDTO dto)
        {
            UserDTO user = new UserDTO();
            UserModel model = ConvertToModel(dto);

            if (!string.IsNullOrEmpty(dto.Email))
                user = ConvertToDto(dbContext.Users.Where(user => user.Email == model.Email).ToList().FirstOrDefault());

            if (!string.IsNullOrEmpty(dto.UserLogin))
                user = ConvertToDto(dbContext.Users.Where(user => user.UserLogin == model.UserLogin).ToList().FirstOrDefault());

            return user;
        }

        public void Update(UserDTO dto) { }

        public void Delete(int pk) { }

        public void Insert(UserDTO dto) { }
    }
}
