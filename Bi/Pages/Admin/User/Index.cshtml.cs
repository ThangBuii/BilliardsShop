using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client.Pages.Admin.User
{
    public class IndexModel : PageModel
    {
        private readonly ICustomHttpClient _request;

        public IndexModel(ICustomHttpClient request)
        {
            _request = request;
        }

        [BindProperty]
        public List<Share.Models.User> Users { get; set; } = new();
        [BindProperty(SupportsGet =true)]
        public string SearchTerm { get; set; }

        //public void OnGet()
        //{
        //    var response = _request.GetAsync("https://localhost:5000/api/User").Result;
        //    Users = response.Content.ReadFromJsonAsync<List<Share.Models.User>>().Result;
        //}

        public async Task OnGetAsync()
        {
            var response = await _request.GetAsync("https://localhost:5000/api/User");
            if (response.IsSuccessStatusCode)
            {
                var users = await response.Content.ReadFromJsonAsync<List<Share.Models.User>>();
                if (!string.IsNullOrEmpty(SearchTerm))
                {
                    Users = users.Where(b => b.Name.Contains(SearchTerm, StringComparison.OrdinalIgnoreCase)).ToList();
                }
                else
                {
                    Users = users;
                }
            }
        }
    }
}
