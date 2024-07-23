using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Share.DTO.UserDTO;
using System.IdentityModel.Tokens.Jwt;

namespace Client.Pages
{
    public class RegisterModel : PageModel
    {
        private readonly ICustomHttpClient _request;

        public RegisterModel(ICustomHttpClient request)
        {
            _request = request;
        }

        [BindProperty]
        public RegisterRequestDTO RegisterRequestDTO { get; set; }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            
            var response = await _request.PostJsonAsync("https://localhost:5000/api/User/Register", RegisterRequestDTO);
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
