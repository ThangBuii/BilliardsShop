using Share.DTO.OrderDetailDTO;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IOrderDetailRepository
    {
        OrderDetail AddOrderDetail(OrderDetail orderDetail);
        OrderDetail GetOrderDetailById(int id);
        List<OrderDetailListResponseDTO> GetOrderDetailsByOrderId(int orderId);
        List<OrderDetail> GetAllOrderDetails();
        bool UpdateOrderDetail(OrderDetail orderDetail);
    }

}
