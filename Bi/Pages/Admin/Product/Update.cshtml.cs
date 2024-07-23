using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Share.DTO.ProductDetailDTO;
using Share.DTO.ProductDTO;
using Share.DTO.ProductImageDTO;
using Share.Models;
using System.Xml.Linq;

namespace Client.Pages.Admin.Product
{
    public class UpdateModel : PageModel
    {
        private readonly ICustomHttpClient _request;

        public UpdateModel(ICustomHttpClient request)
        {
            _request = request;
        }

        [BindProperty]
        public ProductDetailResponseDTO Products { get; set; }
        [BindProperty]
        public List<Share.Models.Category> Categories { get; set; } = new();
        [BindProperty]
        public List<Share.Models.Brand> Brands { get; set; } = new();
        public UpdateProductRequestDTO Productss { get; private set; }
        public UpdateProductDetailDTO ProductDetailss { get; private set; }
        public UpdateProductImageDTO ProductImagess { get; private set; }

        public void OnGet(int id)
        {
            Brands = new List<Share.Models.Brand>();
            var response1 = _request.GetAsync("https://localhost:5000/api/Brand").Result;
            Brands = response1.Content.ReadFromJsonAsync<List<Share.Models.Brand>>().Result;
            Categories = new List<Share.Models.Category>();
            var response2 = _request.GetAsync("https://localhost:5000/api/Category").Result;
            Categories = response2.Content.ReadFromJsonAsync<List<Share.Models.Category>>().Result;
            var response = _request.GetAsync($"https://localhost:5000/api/Product/Detail/{id}").Result;
            Products = response.Content.ReadFromJsonAsync<ProductDetailResponseDTO>().Result;
        }

        public async Task<IActionResult> OnPostAsync(IFormFile productImage1)
        {
            // Ensure that form values are not null or empty
            if (!int.TryParse(Request.Form["CategoryId"], out int categoryId))
            {
                ModelState.AddModelError("", "Invalid category selected.");
                await LoadCategoriesAndBrandsAsync();
                return Page();
            }

            if (!int.TryParse(Request.Form["BrandId"], out int brandId))
            {
                ModelState.AddModelError("", "Invalid brand selected.");
                await LoadCategoriesAndBrandsAsync();
                return Page();
            }

            // Create DTOs with validated data
            var updateProductRequestDTO = new UpdateProductRequestDTO
            {
                CategoryId = categoryId,
                BrandId = brandId,
                UnitsInStock = Products.UnitsInStock,
                IsAvailable = Products.IsAvailable
            };

            // Send DTOs to API
            var response1 = await _request.PutAsync("https://localhost:5000/api/Product", updateProductRequestDTO);
            if (!response1.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Failed to update product.");
                return Page();
            }

            var products = await response1.Content.ReadFromJsonAsync<Share.Models.Product>();
            var updateProductDetailDTO = new UpdateProductDetailDTO
            {
                ProductId = products.Id,
                Name = Products.Name,
                Price = Products.Price,
                Description = Products.Description,
                ShortDescription = Products.ShortDescription,
                Weight = Products.Weight,
                EraserSize = Products.EraserSize,
                ButtLength = Products.ButtLength,
                ShaftLength = Products.ShaftLength,
                Grip = Products.Grip
            };

            var response2 = await _request.PutAsync("https://localhost:5000/api/ProductDetail", updateProductDetailDTO);
            if (!response2.IsSuccessStatusCode)
            {
                ModelState.AddModelError("", "Failed to update product details.");
                return Page();
            }

            // Handle file upload
            if (productImage1 != null && productImage1.Length > 0)
            {
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/product-image/", productImage1.FileName);

                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await productImage1.CopyToAsync(stream);
                }

                var productImageDTO = new AddProductImageDTO
                {
                    ProductId = products.Id,
                    Source = $"/img/product-image/{productImage1.FileName}",
                    IsMainImage = true
                };

                var imageResponse = await _request.PutAsync("https://localhost:5000/api/ProductImage", productImageDTO);
                if (!imageResponse.IsSuccessStatusCode)
                {
                    ModelState.AddModelError("", "Failed to update product image.");
                    return Page();
                }
            }

            return RedirectToPage("/Admin/Product/Index");
        }



        private async Task LoadCategoriesAndBrandsAsync()
        {
            var response1 = await _request.GetAsync("https://localhost:5000/api/Brand");
            Brands = await response1.Content.ReadFromJsonAsync<List<Share.Models.Brand>>();

            var response2 = await _request.GetAsync("https://localhost:5000/api/Category");
            Categories = await response2.Content.ReadFromJsonAsync<List<Share.Models.Category>>();
        }


    }
}
