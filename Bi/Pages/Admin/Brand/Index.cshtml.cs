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

        public void OnGet()
        {
            Brands = new List<Share.Models.Brand>();
            var response = _request.GetAsync("https://localhost:5000/api/Brand").Result;
            Brands = response.Content.ReadFromJsonAsync<List<Share.Models.Brand>>().Result;
        }
    }
}
