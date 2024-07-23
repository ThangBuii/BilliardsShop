using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Share.DTO.ProductDTO;
using Share.Models;

namespace Client.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ICustomHttpClient _request;
        private IHttpContextAccessor _httpContext;

        public IndexModel(ICustomHttpClient request, IHttpContextAccessor httpContext)
        {
            _request = request;
            _httpContext = httpContext;
        }

        [BindProperty]
        public List<ProductListResponseDTO> Products { get; set; } = new();

        public async Task<IActionResult> OnGetAsync()
        {

            await LoadDataAsync();
            return Page();
        }

        private async Task LoadDataAsync()
        {
           
            Products = new List<ProductListResponseDTO>();
      

            
            var productResponse = await _request.GetAsync("https://localhost:5000/api/Product/List");


            if (!productResponse.IsSuccessStatusCode)
            {
                RedirectToPage("/Error500");
                return;
            }

            
            Products = await productResponse.Content.ReadFromJsonAsync<List<ProductListResponseDTO>>();
            Products = Products?.Take(8).ToList();
        }

        public async Task<IActionResult> OnGetAddToCart(int productId)
        {
            await LoadDataAsync();
            CartManager cartManager = new CartManager(_httpContext.HttpContext!.Session);
            cartManager.AddToCart(productId);

            return Page();
        }
    }
}
