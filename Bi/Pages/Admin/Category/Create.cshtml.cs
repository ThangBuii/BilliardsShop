using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Share.DTO.BrandDTO;

namespace Client.Pages.Admin.Category
{
    public class CreateModel : PageModel
    {
        private readonly ICustomHttpClient _request;

        public CreateModel(ICustomHttpClient request)
        {
            _request = request;
        }

        [BindProperty]
        public AddCategoryRequestDTO Categories { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost()
        {
            var response = await _request.PostJsonAsync($"https://localhost:5000/api/Category", Categories);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Admin/Category/Index");
            }
            return Redirect("/Error403");
        }
    }
}
