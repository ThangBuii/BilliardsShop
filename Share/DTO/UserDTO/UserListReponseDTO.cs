using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTO.UserDTO
{
    public class UserListReponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Account { get; set; } = null!;
        
    }
}
