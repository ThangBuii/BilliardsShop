using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Share;
using Share.DTO.OrderDTO;
using Share.Models;

namespace Business.Interfaces
{
    public interface IOrderService
    {
        public List<Order> GetAll();

        public Order Add(AddOrderDTO request);
        public bool Delete(int id);

        public bool Update(UpdateOrderDTO request);

        public List<Order> GetOrderByUserId(int userId);
    }
}
