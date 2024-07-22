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
        private IHttpContextAccessor _httpContext;

        [BindProperty]
        public ProductDetailResponseDTO Product {  get; set; }
        public int ProductID { get; set; }
        public int Quantity { get; set; }
        public ProductDetailModel(ICustomHttpClient request, IHttpContextAccessor httpContext)
        {
            _request = request;
            _httpContext = httpContext;
        }
        public async Task<IActionResult> OnGetAsync([FromQuery] int id)
        {
            Product = new ProductDetailResponseDTO();
            var productResponse = await _request.GetAsync($"https://localhost:5000/api/Product/Detail/{id}");
            Product = await productResponse.Content.ReadFromJsonAsync<ProductDetailResponseDTO>();
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            CartManager cartManager = new CartManager(_httpContext.HttpContext!.Session);
            cartManager.AddToCart(ProductID,Quantity);
            return Redirect("/Category");
        }
    }
}
