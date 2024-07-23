using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Share.DTO.ProductDetailDTO;
using Share.DTO.ProductDTO;
using Share.DTO.ProductImageDTO;

namespace Client.Pages.Admin.Product
{
    public class CreateModel : PageModel
    {
        private readonly ICustomHttpClient _request;

        public CreateModel(ICustomHttpClient request)
        {
            _request = request;
        }

        [BindProperty]
        public List<Share.Models.Category> Categories { get; set; } = new();
        [BindProperty]
        public List<Share.Models.Brand> Brands { get; set; } = new();
        [BindProperty]
        public int Id { get; set; }
        [BindProperty]
        public string Name { get; set; } = string.Empty;
        [BindProperty]
        public double Price { get; set; }
        [BindProperty]
        public int UnitsInStock { get; set; }
        [BindProperty]
        public bool IsAvailable { get; set; }
        [BindProperty]
        public string Description { get; set; } = string.Empty;
        [BindProperty]
        public string ShortDescription { get; set; } = string.Empty;
        [BindProperty]
        public double Weight { get; set; }
        [BindProperty]
        public double EraserSize { get; set; }
        [BindProperty]
        public double ButtLength { get; set; }
        [BindProperty]
        public double ShaftLength { get; set; }
        [BindProperty]
        public string Grip { get; set; } = string.Empty;

        public void OnGet()
        {
            Brands = new List<Share.Models.Brand>();
            var response1 = _request.GetAsync("https://localhost:5000/api/Brand").Result;
            if (!response1.IsSuccessStatusCode)
            {
                 Redirect("/Error403");
            }
            Brands = response1.Content.ReadFromJsonAsync<List<Share.Models.Brand>>().Result;
            if (!response1.IsSuccessStatusCode)
            {
                Redirect("/Error403");
            }
            Categories = new List<Share.Models.Category>();
            var response2 = _request.GetAsync("https://localhost:5000/api/Category").Result;
            if (!response2.IsSuccessStatusCode)
            {
                Redirect("/Error403");
            }
            Categories = response2.Content.ReadFromJsonAsync<List<Share.Models.Category>>().Result;

        }

        public async Task<IActionResult> OnPostAsync(IFormFile productImage1)
        {
            //// Validate model state
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            // Create DTOs
            var addProductRequestDTO = new AddProductRequestDTO
            {
                CategoryId = int.Parse(Request.Form["category"]),
                BrandId = int.Parse(Request.Form["brand"]),
                UnitsInStock = UnitsInStock,
                IsAvailable = IsAvailable
            };

            

            // Send DTOs to API
            var response1 = await _request.PostJsonAsync("https://localhost:5000/api/Product", addProductRequestDTO);
            if (!response1.IsSuccessStatusCode)
            {
                // Handle error (e.g., display message to user)
                return Redirect("/Error403");
            }
            var products = await response1.Content.ReadFromJsonAsync<Share.Models.Product>();
            var addProductDetailDTO = new AddProductDetailDTO
            {
                ProductId = products.Id,
                Name = Name,
                Price = Price,
                Description = Description,
                ShortDescription = ShortDescription,
                Weight = Weight,
                EraserSize = EraserSize,
                ButtLength = ButtLength,
                ShaftLength = ShaftLength,
                Grip = Grip
            };
            var response2 = await _request.PostJsonAsync("https://localhost:5000/api/ProductDetail", addProductDetailDTO);
            if (!response2.IsSuccessStatusCode)
            {
                // Handle error (e.g., display message to user)
                return Redirect("/Error403");
            }

            // Handle file upload
            if (productImage1 != null && productImage1.Length > 0)
            {
                // Define the path to save the image
                var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/img/product-image/", productImage1.FileName);

                // Save the image to the specified path
                using (var stream = new FileStream(imagePath, FileMode.Create))
                {
                    await productImage1.CopyToAsync(stream);
                }

                // Create DTO for image
                var productImageDTO = new AddProductImageDTO
                {
                    ProductId = products.Id,
                    Source = $"/img/product-image/{productImage1.FileName}", // URL path to access the image
                    IsMainImage = true // or set this based on your logic
                };

                // Assuming you have an API endpoint for uploading product images
                var imageResponse = await _request.PostJsonAsync("https://localhost:5000/api/ProductImage", productImageDTO);
                if (!imageResponse.IsSuccessStatusCode)
                {
                    // Handle error (e.g., display message to user)
                    return Redirect("/Error403");
                }
            }

            return RedirectToPage("/Admin/Product/Index");
        }
    }
}
