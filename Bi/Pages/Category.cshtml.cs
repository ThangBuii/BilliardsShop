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

        public CategoryModel(ICustomHttpClient request)
        {
            _request = request;
        }
        [BindProperty]
        public List<Category> Categories { get; set; } = new();
        [BindProperty]
        public List<Brand> Brands { get; set; } = new();
        [BindProperty(SupportsGet =true)]
        public int ProductCount { get; set; }

        [BindProperty]
        public List<ProductListResponseDTO> Products { get; set; } = new();

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
            ProductCount = Products.Count();
        }
    }
}
