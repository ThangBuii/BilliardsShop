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

        public void OnGet()
        {
            Products = new List<Share.Models.Product>();
            var response = _request.GetAsync("https://localhost:5000/api/Product").Result;
            Products = response.Content.ReadFromJsonAsync<List<Share.Models.Product>>().Result;
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            var response = await _request.DeleteAsync($"https://localhost:5000/api/Product/{id}");

            return RedirectToPage("/Admin/Product/Index");
        }
    }
}
