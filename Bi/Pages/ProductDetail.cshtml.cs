using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Share.DTO.ProductDTO;
using Share.Models;

namespace Client.Pages
{
    public class ProductDetailModel : PageModel
    {
        private readonly ICustomHttpClient _request;

        [BindProperty]
        public ProductDetailResponseDTO Product {  get; set; }
        public ProductDetailModel(ICustomHttpClient request)
        {
            _request = request;
        }
        public async Task<IActionResult> OnGetAsync([FromQuery] int id)
        {
            Product = new ProductDetailResponseDTO();
            var productResponse = await _request.GetAsync($"https://localhost:5000/api/Product/Detail/{id}");
            Product = await productResponse.Content.ReadFromJsonAsync<ProductDetailResponseDTO>();
            return Page();
        }
    }
}
