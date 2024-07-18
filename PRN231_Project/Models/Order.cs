using System;
using System.Collections.Generic;

namespace PRN231_Project.Models
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
        public int Status { get; set; }
        public int UserIdbigint { get; set; }

        public virtual User UserIdbigintNavigation { get; set; } = null!;
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
    }
}
