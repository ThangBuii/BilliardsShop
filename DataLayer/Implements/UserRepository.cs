using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implements
{
    public class UserRepository : IUserRepository
    {
        private readonly PRN231_PROJECT_2Context _context;

        public UserRepository(PRN231_PROJECT_2Context context)
        {
            _context = context;
        }

        public User AddUser(User user)
        {
            try
            {
                _context.Users.Add(user);
                _context.SaveChanges();
                return user;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool DeleteUser(int id)
        {
            var user = GetUserById(id);
            if (user == null) return false;
            try
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<User> GetAllUsers()
        {
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(u => u.Id == id);
        }

        public User Login(string email, string password)
        {
            return _context.Users.FirstOrDefault(u => u.Account.Equals(email) && u.Password.Equals(password));
        }

        public bool UpdateUser(User user)
        {
            var originalUser = GetUserById(user.Id);
            if (originalUser == null) return false;

            try
            {
                _context.Entry(originalUser).CurrentValues.SetValues(user);

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
