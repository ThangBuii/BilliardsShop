using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Share.DTO.BrandDTO;

namespace Client.Pages.Admin.Category
{
    public class UpdateModel : PageModel
    {
        private readonly ICustomHttpClient _request;

        public UpdateModel(ICustomHttpClient request)
        {
            _request = request;
        }

        [BindProperty]
        public EditCategoryRequestDTO Categories { get; set; }



        public async Task<IActionResult> OnGet(int id)
        {
            var response = await _request.GetAsync($"https://localhost:5000/api/Category/GetById/{id}");
            if (response.IsSuccessStatusCode)
            {
                Categories = await response.Content.ReadFromJsonAsync<EditCategoryRequestDTO>();
                if (Categories == null)
                {
                    return NotFound();
                }
                return Page();
            }
            return NotFound();
        }

        public async Task<IActionResult> OnPost()
        {
            var response = await _request.PutAsync($"https://localhost:5000/api/Category", Categories);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToPage("/Admin/Category/Index");
            }
            ModelState.AddModelError(string.Empty, "Unable to update categories.");
            return Page();
        }
    }
}
