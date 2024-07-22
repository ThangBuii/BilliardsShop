﻿using Business.Implements;
using Business.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Share.DTO.ProductDetailDTO;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductDetailController : ControllerBase
    {
        private readonly IProductDetailService _productDetailService;

        public ProductDetailController(IProductDetailService productDetailService)
        {
            _productDetailService = productDetailService;
        }

       

        private static string MESSAGE = "An unexpected error occurred. Please try again later.";
        

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_productDetailService.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });
            }
        }

        [HttpPost]
        public IActionResult Post(AddProductDetailDTO request)
        {
            try
            {
                return Ok(_productDetailService.Add(request));
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
                return Ok(_productDetailService.Delete(id));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });
            }
        }

        [HttpPut]
        public IActionResult Update(UpdateProductDetailDTO request)
        {
            try
            {
                return Ok(_productDetailService.Update(request));
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { message = MESSAGE });
            }
        }
    }
}