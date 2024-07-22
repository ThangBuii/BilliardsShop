using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Share.DTO.OrderDetailDTO;
using Share.Models;

namespace Client.Pages.Account.Order
{
    public class OrderDetailModel : PageModel
    {

        private readonly ICustomHttpClient _request;

        public OrderDetailModel(ICustomHttpClient request)
        {
            _request = request;
        }
        [BindProperty]
        public List<OrderDetailListResponseDTO> OrderDetails { get; set; }
        public async Task<IActionResult> OnGetAsync([FromQuery] int orderID)
        {
            var orderResponse = await _request.GetAsync($"https://localhost:5000/api/OrderDetail/{orderID}");
            if (!orderResponse.IsSuccessStatusCode)
            {
                return Redirect("/Error500");
            }
            OrderDetails = await orderResponse.Content.ReadFromJsonAsync<List<OrderDetailListResponseDTO>>();
            return Page();
        }
    }
}
