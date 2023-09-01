using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string? UserLogin { get; set; }
        public string? Password { get; set; }
        public string? Email { get; set; }
        public string? Login { get; set; }
    }
}
