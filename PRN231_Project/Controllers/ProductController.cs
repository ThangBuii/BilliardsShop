using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Share.DTO.ProductDTO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        private static string MESSAGE = "An unexpected error occurred. Please try again later.";

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetAllAdmin()
        {
            try
            {
                return Ok(_productService.GetAllAdmin());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });

            }
        }

        [HttpGet("List")]
        public IActionResult GetAllShop()
        {
            try
            {
                return Ok(_productService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });

            }
        }

        [HttpGet("{brandId}")]
        public IActionResult GetByBrand(int brandId)
        {
            try
            {
                return Ok(_productService.GetAllByBrand(brandId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });

            }
        }

        [HttpGet("{categoryId}")]
        public IActionResult GetByCategory(int categoryId)
        {
            try
            {
                return Ok(_productService.GetAllByCategory(categoryId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });

            }
        }

        [HttpGet("{categoryId}/{brandId}")]
        public IActionResult GetByBrandAndCate(int categoryId,int brandId)
        {
            try
            {
                return Ok(_productService.GetAllByCategoryAndBrand(categoryId,brandId));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });

            }
        }

        [HttpGet("Detail/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_productService.GetProductById(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });

            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                return Ok(_productService.Delete(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });

            }
        }

        [HttpPut]
        public IActionResult Update(UpdateProductRequestDTO request)
        {
            try
            {
                return Ok(_productService.Update(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });

            }
        }

        [HttpPost]
        public IActionResult Add(AddProductRequestDTO request)
        {
            try
            {
                return Ok(_productService.Add(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });

            }
        }
    }
}
