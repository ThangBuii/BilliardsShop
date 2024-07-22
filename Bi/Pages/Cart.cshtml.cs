using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Share.DTO.ProductDTO;
using Share.Models;

namespace Client.Pages
{
    public class CartModel : PageModel
    {
        private IHttpContextAccessor _httpContext;
        private readonly ICustomHttpClient _request;
        [BindProperty]
        public List<ProductCartDTO> Carts { get; set; }

        [BindProperty]
        public double SubTotal { get; set; }

        public CartModel(IHttpContextAccessor httpContext, ICustomHttpClient request)
        {
            _httpContext = httpContext;
            _request = request;
            Carts = new List<ProductCartDTO>();
            SubTotal = 0;
        }

        

        
        public async Task<IActionResult> OnGetAsync()
        {
            
            Dictionary<int,int> cart = (new CartManager(_httpContext.HttpContext!.Session)).GetProducts();
            foreach (var productId in cart.Keys)
            {
                var productResponse = await _request.GetAsync($"https://localhost:5000/api/Product/Detail/{productId}");
                var product = await productResponse.Content.ReadFromJsonAsync<ProductDetailResponseDTO>();
                var cartProduct = new ProductCartDTO
                {
                    Id = productId,
                    Name = product.Name,
                    ImgSource = product.ImgSource[0],
                    UnitsInStock = product.UnitsInStock,
                    Price = product.Price,
                    Quantity = cart[productId],
                    Total = cart[productId] * product.Price
                };
                SubTotal += cartProduct.Total;
                Carts.Add(cartProduct);
            }

            return Page();

        }
    }
}
