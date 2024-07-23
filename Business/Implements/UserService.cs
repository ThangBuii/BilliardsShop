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

        public List<UserListReponseDTO> GetAllUsers()
        {
            var list =  _userRepo.GetAllUsers().Select(u => new UserListReponseDTO
            {
                Id = u.Id,
                Name = u.Name,
                Account = u.Email,
            });
            return list.ToList();
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
                Email = request.Email,
                Password = request.Password,
                Role = 2
            };
            var newUser = _userRepo.AddUser(user);
            return newUser;
        }

        public User GetUserById(int id)
        {
            return _userRepo.GetUserById(id);
        }

        public bool ChangePassword(ChangePasswordRequestDTO request)
        {
            return _userRepo.ChangePassword(request);
        }
    }
}
