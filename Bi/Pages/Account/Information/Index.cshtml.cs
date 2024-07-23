using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Share.Models;

namespace Client.Pages.Account.Information
{
    public class IndexModel : PageModel
    {
        private readonly ICustomHttpClient _request;

        public IndexModel(ICustomHttpClient request)
        {
            _request = request;
        }

        [BindProperty]
        public Share.Models.User User { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            var userIdString = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out var userId))
            {
                // If userId is not found or is invalid, redirect to error page
                return Redirect("/Error403");
            }
            var userResponse = await _request.GetAsync($"https://localhost:5000/api/User/GetUserById/{userId}");
            if (!userResponse.IsSuccessStatusCode)
            {
                return Redirect("/Error500");
            }
            User = await userResponse.Content.ReadFromJsonAsync<Share.Models.User>();

            return Page();

        }
    }
}
