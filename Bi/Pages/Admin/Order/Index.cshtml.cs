using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages.Admin.Order
{
    public class IndexModel : PageModel
    {
        private readonly ICustomHttpClient _request;

        public IndexModel(ICustomHttpClient request)
        {
            _request = request;
        }

        [BindProperty]
        public List<Share.Models.Order> Orders { get; set; } = new();

        public void OnGet()
        {
            Orders = new List<Share.Models.Order>();
            var response = _request.GetAsync("https://localhost:5000/api/Order").Result;
            Orders = response.Content.ReadFromJsonAsync<List<Share.Models.Order>>().Result;
        }
    }
}
