using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages.Admin.Brand
{
    public class IndexModel : PageModel
    {
        private readonly ICustomHttpClient _request;

        public IndexModel(ICustomHttpClient request)
        {
            _request = request;
        }

        [BindProperty]
        public List<Share.Models.Brand> Brands { get; set; } = new();
        [BindProperty(SupportsGet = true)]
        public string SearchTerm { get; set; }

        //public void OnGet()
        //{
        //    Brands = new List<Share.Models.Brand>();
        //    var response = _request.GetAsync("https://localhost:5000/api/Brand").Result;
        //    Brands = response.Content.ReadFromJsonAsync<List<Share.Models.Brand>>().Result;
        //}
        public async Task OnGetAsync()
        {
            var response = await _request.GetAsync("https://localhost:5000/api/Brand");
            if (response.IsSuccessStatusCode)
            {
                var brands = await response.Content.ReadFromJsonAsync<List<Share.Models.Brand>>();
                if (!string.IsNullOrEmpty(SearchTerm))
                {
                    Brands = brands.Where(b => b.Name.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                else
                {
                    Brands = brands;
                }
            }
        }


        public async Task<IActionResult> OnGetDelete(int id)
        {
            var response = await _request.DeleteAsync($"https://localhost:5000/{id}");
            
            return RedirectToPage("/Admin/Brand/Index");
        }
    }
}
