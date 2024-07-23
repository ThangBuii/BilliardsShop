using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Share.DTO.UserDTO;

namespace Client.Pages.Account.ChangePassword
{
    public class IndexModel : PageModel
    {
        private readonly ICustomHttpClient _request;

        public IndexModel(ICustomHttpClient request)
        {
            _request = request;
        }

        [BindProperty]
        public ChangePasswordRequestDTO ChangePasswordRequest { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            var userIdString = HttpContext.Session.GetString("userId");
            if (string.IsNullOrEmpty(userIdString) || !int.TryParse(userIdString, out var userId))
            {
                // If userId is not found or is invalid, redirect to error page
                return Redirect("/Error403");
            }
            ChangePasswordRequest.UserId = userId;
     
            var response = await _request.PostJsonAsync("https://localhost:5000/api/User/ChangePassword", ChangePasswordRequest);
            if(!response.IsSuccessStatusCode)
            {
                return Redirect("/Error500");
            }
           
            return Redirect("/Index");
        }
    }
}
