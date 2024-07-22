using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages.Account.Order
{
    public class OrderDetailModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public int OrderId { get; set; }
        public void OnGet([FromQuery] int orderID)
        {
        }
    }
}
