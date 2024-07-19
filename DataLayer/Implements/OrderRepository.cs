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
    public class OrderRepository : IOrderRepository
    {
        private readonly PRN231_PROJECT_2Context _context;

        public OrderRepository(PRN231_PROJECT_2Context context)
        {
            _context = context;
        }

        public Order AddOrder(Order order)
        {
            try
            {
                _context.Orders.Add(order);
                _context.SaveChanges();
                return order;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool DeleteOrder(int id)
        {
            var order = GetOrderById(id);
            if (order == null) return false;
            try
            {
                var orderDetails = _context.OrderDetails.Where(x => x.OrderId == order.Id).ToList();
                _context.OrderDetails.RemoveRange(orderDetails);
                _context.Orders.Remove(order);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Order> GetAllOrders()
        {
            return _context.Orders.ToList();
        }

        public Order GetOrderById(int id)
        {
            return _context.Orders.FirstOrDefault(o => o.Id == id);
        }

        public bool UpdateOrder(Order order)
        {
            var originalOrder = GetOrderById(order.Id);
            if (originalOrder == null) return false;

            try
            {
                _context.Entry(originalOrder).CurrentValues.SetValues(order);

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Order> GetOrdersByUserId(int userId)
        {
            var orders = _context.Orders.Where(o => o.UserIdbigint == userId);
            return orders.ToList();
        }

        
    }
}
