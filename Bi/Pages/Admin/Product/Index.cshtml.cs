using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages.Admin.Product
{
    public class IndexModel : PageModel
    {
        private readonly ICustomHttpClient _request;

        public IndexModel(ICustomHttpClient request)
        {
            _request = request;
        }

        [BindProperty]
        public List<Share.Models.Product> Products { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {
            Products = new List<Share.Models.Product>();
            var response = _request.GetAsync("https://localhost:5000/api/Product").Result;
            if (!response.IsSuccessStatusCode)
            {
                return Redirect("/Error403");
    
            }
            Products = response.Content.ReadFromJsonAsync<List<Share.Models.Product>>().Result;
            return Page();
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            var response = await _request.DeleteAsync($"https://localhost:5000/api/Product/{id}");
            if (!response.IsSuccessStatusCode)
            {
                return Redirect("/Error403");
            }

            return RedirectToPage("/Admin/Product/Index");
        }
    }
}
