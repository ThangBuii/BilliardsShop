using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages.Account
{
    public class LogOutModel : PageModel
    {
        public void OnGet()
        {
            // Clear the session
            HttpContext.Session.Clear();

            // Delete the JWT token cookie
            if (Request.Cookies.ContainsKey("jwtToken"))
            {
                Response.Cookies.Delete("jwtToken");
            }

            // Redirect to home or login page after logout
            Response.Redirect("/Index");
        }
    }
}
