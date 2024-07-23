using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Share;
using Share.DTO.UserDTO;
using Share.Models;

namespace Business.Interfaces
{
    public interface IUserService
    {
        public User FindUser(LoginRequestDTO requestDTO);

        public List<UserListReponseDTO> GetAllUsers();
        User GetUserById(int id);

        public User RegisterUser(RegisterRequestDTO request);
    }
}
