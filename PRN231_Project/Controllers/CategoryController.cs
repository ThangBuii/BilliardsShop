using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Share.DTO.BrandDTO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService _categoryService;
        private static string MESSAGE = "An unexpected error occurred. Please try again later.";

        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var list = _categoryService.GetAll();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });
            }
        }

        [HttpGet("GetById/{id}")]
        public IActionResult GetCategoryById(int id)
        {
            try
            {
                var category = _categoryService.GetById(id);
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });
            }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] AddCategoryRequestDTO request)
        {
            try
            {
                var category = _categoryService.AddCategory(request);
                if (category == null)
                {
                    return BadRequest();
                }
                return Ok(category);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });
            }
        }

        [HttpDelete("{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                var success = _categoryService.DeleteCategory(id);
                if (!success)
                {
                    return StatusCode(500, new { message = MESSAGE });
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });
            }
        }

        [HttpPut]
        //[Authorize(Roles = "Admin")]
        public IActionResult Put([FromBody] EditCategoryRequestDTO request)
        {
            try
            {
                var success = _categoryService.UpdateCategory(request);
                if (!success)
                {
                    return StatusCode(500, new { message = MESSAGE });
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });
            }
        }
    }
}
