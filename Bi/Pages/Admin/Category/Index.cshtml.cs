using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Share.Models;

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
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        //public void OnGet()
        //{
        //    Categories = new List<Share.Models.Category>();
        //    var response = _request.GetAsync("https://localhost:5000/api/Category").Result;
        //    Categories = response.Content.ReadFromJsonAsync<List<Share.Models.Category>>().Result;
        //}
        public async Task OnGetAsync()
        {
            var response = await _request.GetAsync("https://localhost:5000/api/Category");
            if (response.IsSuccessStatusCode)
            {
                var categories = await response.Content.ReadFromJsonAsync<List<Share.Models.Category>>();
                if (!string.IsNullOrEmpty(SearchTerm))
                {
                    Categories = categories.Where(b => b.Name.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                else
                {
                    Categories = categories;
                }
            }
        }

        public async Task<IActionResult> OnGetDelete(int id)
        {
            var response = await _request.DeleteAsync($"https://localhost:5000/api/Category/{id}");

            return RedirectToPage("/Admin/Category/Index");
        }
    }
}
