using Business.Interfaces;
using DataLayer.Interfaces;
using Share.DTO.BrandDTO;
using Share.DTO.OrderDetailDTO;
using Share.DTO.OrderDTO;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class OrderDetailService : IOrderDetailService
    {
        private readonly IOrderDetailRepository _orderDetailRepository;

        public OrderDetailService(IOrderDetailRepository orderDetailRepository)
        {
            _orderDetailRepository = orderDetailRepository;
        }

        public OrderDetail Add(AddOrderDetailDTO request)
        {
            return _orderDetailRepository.AddOrderDetail(new OrderDetail
            {
                OrderId = request.OrderId,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice,
            });
        }

        public List<OrderDetail> GetAll()
        {
            return _orderDetailRepository.GetAllOrderDetails();
        }

        public List<OrderDetailListResponseDTO> GetOrderByOrderId(int orderId)
        {
            return _orderDetailRepository.GetOrderDetailsByOrderId(orderId);
        }

        public bool Update(UpdateOrderDetailDTO request)
        {
            return _orderDetailRepository.UpdateOrderDetail(new OrderDetail
            {
                Id = request.Id,
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                UnitPrice = request.UnitPrice,
                OrderId = request.OrderId,
            });
        }
    }
}
