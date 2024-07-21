using System;
using System.Collections.Generic;

namespace Share.Models
{
    public partial class Order
    {
        public Order()
        {
            OrderDetails = new HashSet<OrderDetail>();
        }

        public int Id { get; set; }
        public DateTime Date { get; set; }
        public double Total { get; set; }
        public string ShippingAddress { get; set; } = null!;
        public string Note { get; set; } = null!;
        public int Status { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
