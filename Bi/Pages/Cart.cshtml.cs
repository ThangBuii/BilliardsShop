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
        public Dictionary<Product, int> Cart { get; set; } = null!;

        public CartModel(IHttpContextAccessor httpContext, ICustomHttpClient request)
        {
            _httpContext = httpContext;
            _request = request;
            Cart = new Dictionary<Product, int>();
        }

        

        
        public void OnGet()
        {
            Dictionary<int,int> cart = (new CartManager(_httpContext.HttpContext!.Session)).GetProducts();

        }
    }
}
