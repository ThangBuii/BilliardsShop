using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Share.DTO.BrandDTO;

namespace Client.Pages.Admin.Brand
{
    public class UpdateModel : PageModel
    {
        private readonly ICustomHttpClient _request;

        public UpdateModel(ICustomHttpClient request)
        {
            _request = request;
        }

        [BindProperty]
        public EditBrandRequestDTO Brands { get; set; }



        public async Task<IActionResult> OnGet(int id)
        {
            var response = await _request.GetAsync($"https://localhost:5000/{id}");
            if (response.IsSuccessStatusCode)
            {
                Brands = await response.Content.ReadFromJsonAsync<EditBrandRequestDTO>();
                if (Brands == null)
                {
                    return NotFound();
                }
                return Page();
            }
            return Redirect("/Error403");
        }

        public async Task<IActionResult> OnPost()
        {
            var response = await _request.PutAsync($"https://localhost:5000/api/Brand", Brands);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Admin/Brand/Index");
            }
            return Redirect("/Error403");
        }
    }
}
