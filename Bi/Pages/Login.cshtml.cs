using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net.Http;
using Share.DTO;
using Share.DTO.UserDTO;
using System.IdentityModel.Tokens.Jwt;

namespace Client.Pages
{
    public class LoginModel : PageModel
    {
        private readonly ICustomHttpClient _request;

        public LoginModel(ICustomHttpClient request)
        {
            _request = request;
        }

        [BindProperty]
        public string Email { get; set; }
        [BindProperty]
        public string Password { get; set; }
        public void OnGet()
        {

        }

        public async Task<IActionResult> OnPost()
        {
            var loginRequest = new LoginRequestDTO { Email = Email, Password = Password };
            var response = await _request.PostJsonAsync("https://localhost:5000/api/User/Login", loginRequest);
            if (response.IsSuccessStatusCode)
            {
                var loginResponse = await response.Content.ReadFromJsonAsync<TokenResponseDTO>();
                var token = loginResponse.Token;

				var handler = new JwtSecurityTokenHandler();
				var jsonToken = handler.ReadToken(token) as JwtSecurityToken;
				var userId = jsonToken.Claims.FirstOrDefault(claim => claim.Type == "UserId").Value;
				// Store the userId in the session
				HttpContext.Session.SetString("userId", userId);


				var cookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true,
                    Expires = DateTime.UtcNow.AddDays(1)
                };

                Response.Cookies.Append("jwtToken", token, cookieOptions);
                return RedirectToPage("/Index");
            }

            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return Page();
        }
    }
}
