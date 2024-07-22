using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages.Admin.Category
{
    public class IndexModel : PageModel
    {
        private readonly ICustomHttpClient _request;

        public IndexModel(ICustomHttpClient request)
        {
            _request = request;
        }

        [BindProperty]
        public List<Share.Models.Category> Categories { get; set; } = new();

        public void OnGet()
        {
            Categories = new List<Share.Models.Category>();
            var response = _request.GetAsync("https://localhost:5000/api/Category").Result;
            Categories = response.Content.ReadFromJsonAsync<List<Share.Models.Category>>().Result;
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            var response = await _request.DeleteAsync($"https://localhost:5000/api/Category/{id}");

            return RedirectToPage("/Admin/Category/Index");
        }
    }
}
