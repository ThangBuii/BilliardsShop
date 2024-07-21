using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Share.DTO.OrderDTO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly IOrderDetailService _orderDetailService;

        public OrderDetailController(IOrderDetailService orderDetailService)
        {
            _orderDetailService = orderDetailService;
        }

        private static string MESSAGE = "An unexpected error occurred. Please try again later.";
       

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_orderDetailService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });
            }
        }

        [HttpPost]
        public IActionResult Post(AddOrderDetailDTO request)
        {
            try
            {
                return Ok(_orderDetailService.Add(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });
            }
        }

        

        [HttpPut]
        public IActionResult Update(UpdateOrderDetailDTO request)
        {
            try
            {
                return Ok(_orderDetailService.Update(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });
            }
        }

        [HttpGet("{orderId}")]
        public IActionResult GetOrderDetailByOrderId(int orderId)
        {
            try
            {
                return Ok(_orderDetailService.GetOrderByOrderId(orderId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });
            }
        }
    }
}
