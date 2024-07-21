using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Share.DTO.OrderDetailDTO;
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

        public List<OrderDetailListResponseDTO> GetOrderDetailsByOrderId(int orderId)
        {
            var list = _context.OrderDetails.Include(od => od.Product)
                                                .ThenInclude(o => o.ProductDetail)
                                            .Include(od => od.Product)
                                                .ThenInclude(p => p.ProductImages).Select(od => new OrderDetailListResponseDTO
            {
                Id = od.Id,
                OrderId = od.OrderId,
                ProductName = od.Product.ProductDetail.Name,
                Quantity = od.Quantity,
                UnitPrice = od.UnitPrice,
                TotalPrice = od.Quantity * od.UnitPrice,
                ImgSource = od.Product.ProductImages.FirstOrDefault(pi => pi.IsMainImage).Source
            }).Where(o => o.OrderId == orderId).ToList();
            return list;
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
