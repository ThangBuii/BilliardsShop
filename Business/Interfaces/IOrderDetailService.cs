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
    public interface IOrderDetailService
    {
        public List<OrderDetail> GetAll();

        public OrderDetail Add(AddOrderDetailDTO request);

        public bool Update(UpdateOrderDetailDTO request);

        public List<OrderDetail> GetOrderByOrderId(int orderId);
    }
}
