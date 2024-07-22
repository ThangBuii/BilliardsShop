using Client.Pages.Shared;
using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Share.DTO.ProductDTO;
using Share.DTO.UserDTO;
using Share.Models;

namespace Client.Pages
{
    public class CategoryModel : PageModel
    {
        private readonly ICustomHttpClient _request;
        private IHttpContextAccessor _httpContext;

        public CategoryModel(ICustomHttpClient request, IHttpContextAccessor httpContext)
        {
            _request = request;
            _httpContext = httpContext;
        }
        [BindProperty]
        public List<Category> Categories { get; set; } = new();
        [BindProperty]
        public List<Brand> Brands { get; set; } = new();
        [BindProperty(SupportsGet =true)]
        public int ProductCount { get; set; }

        [BindProperty]
        public List<ProductListResponseDTO> Products { get; set; } = new();

        [BindProperty]
        public List<ProductListResponseDTO> TopProducts { get; set; } = new();
        [BindProperty(SupportsGet = true)]
        public int CurrentPage { get; set; } = 1;

        [BindProperty(SupportsGet = true)]
        public int PageSize { get; set; } = 9;

        [BindProperty]
        public int TotalPages => (int)Math.Ceiling((double)ProductCount / PageSize);


        public async Task<IActionResult> OnGetAsync()
        {

            await LoadDataAsync();
            return Page();
        }

        public async Task<IActionResult> OnGetSearchByCateAsync(int id)
        {
            await LoadDataAsync();

            // Handle search by category logic
            if (id != 0)
            {
                var productResponse = await _request.GetAsync($"https://localhost:5000/api/Product/Category/{id}");
                Products = await productResponse.Content.ReadFromJsonAsync<List<ProductListResponseDTO>>();
                ProductCount = Products.Count();
                // Add logic to filter or use SearchCategoryId as needed
            }

            return Page();
        }

        public async Task<IActionResult> OnGetSearchByBrandAsync(int id)
        {
            await LoadDataAsync();

            // Handle search by category logic
            if (id != 0)
            {
                var productResponse = await _request.GetAsync($"https://localhost:5000/api/Product/Brand/{id}");
                Products = await productResponse.Content.ReadFromJsonAsync<List<ProductListResponseDTO>>();
                ProductCount = Products.Count();
                // Add logic to filter or use SearchCategoryId as needed
            }

            return Page();
        }

        private async Task LoadDataAsync()
        {
            Categories = new List<Category>();
            Brands = new List<Brand>();
            Products = new List<ProductListResponseDTO>();
            ProductCount = 0;

            var categoryResponse = await _request.GetAsync("https://localhost:5000/api/Category");
            var brandResponse = await _request.GetAsync("https://localhost:5000/api/Brand");
            var productResponse = await _request.GetAsync("https://localhost:5000/api/Product/List");


            if (!categoryResponse.IsSuccessStatusCode || !brandResponse.IsSuccessStatusCode || !productResponse.IsSuccessStatusCode)
            {
                RedirectToPage("/_Page500");
                return;
            }

            Categories = await categoryResponse.Content.ReadFromJsonAsync<List<Category>>();
            Brands = await brandResponse.Content.ReadFromJsonAsync<List<Brand>>();
            Products = await productResponse.Content.ReadFromJsonAsync<List<ProductListResponseDTO>>();
            TopProducts = Products.Take(8).ToList();
            ProductCount = Products.Count();
        }

        public async Task<IActionResult> OnGetAddToCart(int currentPage,int productId)
        {
            await LoadDataAsync();
            CurrentPage = currentPage;
            var token = Request.Cookies["jwtToken"];
            if (string.IsNullOrEmpty(token))
            {
                // Token is not present, redirect to login page with a message
                TempData["Message"] = "Please log in to proceed with shopping.";
                return RedirectToPage("/Login");
            }
            CartManager cartManager = new CartManager(_httpContext.HttpContext!.Session);
            cartManager.AddToCart(productId);
            
            return Page();
        }
    }
}
