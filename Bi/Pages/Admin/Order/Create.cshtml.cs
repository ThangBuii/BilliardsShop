using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Share.DTO.OrderDTO;

namespace Client.Pages.Admin.Order
{
    public class CreateModel : PageModel
    {
        private readonly ICustomHttpClient _request;

        public CreateModel(ICustomHttpClient request)
        {
            _request = request;
        }
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public DateTime Date { get; set; }
        [BindProperty]
        public double Total { get; set; }
        [BindProperty]
        public string ShippingAddress { get; set; } = string.Empty;
        [BindProperty]
        public int Status { get; set; }
        [BindProperty]
        public int UserId { get; set; }
        [BindProperty]
        public string Note { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            var addOrderDTO = new AddOrderDTO
            {
                Date = Date,
                Total = Total,
                ShippingAddress = ShippingAddress,
                Status = Status,
                UserId = UserId,
                Note = Note
            };

            var response = await _request.PostJsonAsync("https://localhost:5000/api/Order", addOrderDTO);
            if (!response.IsSuccessStatusCode)
            {
                return Redirect("/Error403");
            }

            return RedirectToPage("/Admin/Order/Index");
        }
    }
}
