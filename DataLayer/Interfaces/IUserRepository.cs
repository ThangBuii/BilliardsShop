using Share.DTO.UserDTO;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IUserRepository
    {
        public User AddUser(User user);
        User GetUserById(int id);
        List<User> GetAllUsers();
        bool UpdateUser(User user);
        bool DeleteUser(int id);
        public User Login(string email,string password);
        bool ChangePassword(ChangePasswordRequestDTO request);
    }
}
