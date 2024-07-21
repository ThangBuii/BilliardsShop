using Business.Interfaces;
using DataLayer.Interfaces;
using Share.DTO.BrandDTO;
using Share.DTO.OrderDTO;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;

        public OrderService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public Order Add(AddOrderDTO request)
        {
            return _orderRepository.AddOrder(new Order
            {
                Date = request.Date,
                ShippingAddress = request.ShippingAddress,
                Status = request.Status,
                Note = request.Note,
                Total = request.Total,
                UserId = request.UserId,
            });
        }

        public bool Delete(int id)
        {
            return _orderRepository.DeleteOrder(id);
        }

        public List<Order> GetAll()
        {
            return _orderRepository.GetAllOrders();
        }

        public List<Order> GetOrderByUserId(int userId)
        {
            return _orderRepository.GetOrdersByUserId(userId);
        }

      

        public bool Update(UpdateOrderDTO request)
        {
            return _orderRepository.UpdateOrder(new Order
            {
                Date = request.Date,
                ShippingAddress = request.ShippingAddress,
                Status = request.Status,
                Total = request.Total,
                Note = request.Note,
                UserId = request.UserId,
                Id = request.Id,
            });
        }
    }
}
