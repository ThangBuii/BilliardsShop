using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Share.Models;

namespace Client.Pages.Account.Order
{
    public class IndexModel : PageModel
    {
		private readonly ICustomHttpClient _request;

		public IndexModel(ICustomHttpClient request)
		{
			_request = request;
		}

		[BindProperty]
		public List<Share.Models.Order> Orders { get; set; }

		public async Task<IActionResult> OnGetAsync()
        {
			var userIdString = HttpContext.Session.GetString("userId");
			if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out var userId))
			{
				// If userId is not found or is invalid, redirect to error page
				return Redirect("/Error403");
			}
			var orderResponse = await _request.GetAsync($"https://localhost:5000/api/Order/{userId}");
			if (!orderResponse.IsSuccessStatusCode)
			{
				return Redirect("/Error500");
			}
			Orders = await orderResponse.Content.ReadFromJsonAsync<List<Share.Models.Order>>();

			return Page();

		}
    }
}
