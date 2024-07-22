using Business.Implements;
using Business.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Share.DTO.BrandDTO;
using System.Reflection.Metadata;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandController : ControllerBase
    {
        private readonly IBrandService _brandService;
        private static string MESSAGE = "An unexpected error occurred. Please try again later.";

        public BrandController(IBrandService brandService)
        {
            _brandService = brandService;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                var list = _brandService.GetAll();
                return Ok(list);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });
            }
        }

        [HttpGet("/{id}")]
        public IActionResult GetBrandsById(int id)
        {
            try
            {
                var brand = _brandService.GetById(id);
                return Ok(brand);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });
            }
        }

        [HttpPost]
        //[Authorize(Roles = "Admin")]
        public IActionResult Post([FromBody] AddBrandRequestDTO request)
        {
            try
            {
                var brand = _brandService.AddBrand(request);
                if (brand == null)
                {
                    return BadRequest();
                }
                return Ok(brand);
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });
            }
        }

        [HttpDelete("/{id}")]
        //[Authorize(Roles = "Admin")]
        public IActionResult Delete(int id)
        {
            try
            {
                var boolean = _brandService.DeleteBrand(id);
                if (!boolean)
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
        public IActionResult Put([FromBody] EditBrandRequestDTO request)
        {
            try
            {
                var boolean = _brandService.UpdateBrand(request);
                if (!boolean)
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
