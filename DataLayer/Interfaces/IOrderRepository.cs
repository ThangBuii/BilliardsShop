using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IOrderRepository
    {
        Order AddOrder(Order order);
        Order GetOrderById(int id);
        List<Order> GetAllOrders();
        List<Order> GetOrdersByUserId(int userId);
        bool UpdateOrder(Order order);
        bool DeleteOrder(int id);
    }

}
