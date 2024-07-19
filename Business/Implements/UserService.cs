using Business.Interfaces;
using DataLayer.Interfaces;
using Share.DTO.UserDTO;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepo;

        public UserService(IUserRepository userRepo)
        {
            _userRepo = userRepo;
        }

        public List<User> GetAllUsers()
        {
            return _userRepo.GetAllUsers();
        }

        public User FindUser(LoginRequestDTO requestDTO)
        {
            var user = _userRepo.Login(requestDTO.Email, requestDTO.Password);
            return user;
        }

        public User RegisterUser(RegisterRequestDTO request)
        {
            var user = new User
            {
                Name = request.Name,
                Account = request.Email,
                Password = request.Password,
                Role = 2
            };
            var newUser = _userRepo.AddUser(user);
            return newUser;
        }
    }
}
