using Client.WebRequests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Share.DTO.ProductDTO;
using Share.Models;

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

    }
}
