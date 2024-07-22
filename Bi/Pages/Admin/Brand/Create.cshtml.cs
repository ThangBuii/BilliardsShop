using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Share.DTO.BrandDTO;

namespace Client.Pages.Admin.Brand
{
    public class CreateModel : PageModel
    {
        private readonly ICustomHttpClient _request;

        public CreateModel(ICustomHttpClient request)
        {
            _request = request;
        }

        [BindProperty]
        public AddBrandRequestDTO Brands { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost() { 
            var response = await _request.PostJsonAsync($"https://localhost:5000/api/Brand", Brands);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Admin/Brand/Index");
            }
            ModelState.AddModelError(string.Empty, "Unable to Add brand.");
            return Page();
        }
    }
}
