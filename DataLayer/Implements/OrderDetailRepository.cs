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
    public class OrderDetailRepository : IOrderDetailRepository
    {
        private readonly PRN231_PROJECT_2Context _context;

        public OrderDetailRepository(PRN231_PROJECT_2Context context)
        {
            _context = context;
        }

        public OrderDetail AddOrderDetail(OrderDetail orderDetail)
        {
            try
            {
                _context.OrderDetails.Add(orderDetail);
                _context.SaveChanges();
                return orderDetail;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public List<OrderDetail> GetAllOrderDetails()
        {
            return _context.OrderDetails.ToList();
        }

        public OrderDetail GetOrderDetailById(int id)
        {
            return _context.OrderDetails.FirstOrDefault(od => od.Id == id);
        }

        public List<OrderDetail> GetOrderDetailsByOrderId(int orderId)
        {
            return _context.OrderDetails.Where(od => od.OrderId == orderId).ToList();
        }

        public bool UpdateOrderDetail(OrderDetail orderDetail)
        {
            var originalOrderDetail = GetOrderDetailById(orderDetail.Id);
            if (originalOrderDetail == null) return false;

            try
            {
                _context.Entry(originalOrderDetail).CurrentValues.SetValues(orderDetail);

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
