using System;
using System.Collections.Generic;

namespace Share.Models
{
    public partial class User
    {
        public User()
        {
            Orders = new HashSet<Order>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string Password { get; set; } = null!;
        public int Role { get; set; }
        public bool IsEnabled { get; set; }

        public virtual ICollection<Order> Orders { get; set; }
    }
}
