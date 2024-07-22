using Business.Interfaces;
using DataLayer.Interfaces;
using Share.DTO.ProductDTO;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepo;

        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public Product Add(AddProductRequestDTO request)
        {
            return _productRepo.AddProduct(new Product
            {
                BrandId = request.BrandId,
                CategoryId = request.CategoryId,
                IsAvailable = request.IsAvailable,
                UnitsInStock = request.UnitsInStock,
            });
        }

        public bool Delete(int id)
        {
            return _productRepo.DeleteProduct(id);
        }

        public List<ProductListResponseDTO> GetAll()
        {
            return _productRepo.GetAllProducts();
        }

        public List<Product> GetAllAdmin()
        {
            return _productRepo.GetAllProductsAdmin();
        }

        public List<ProductListResponseDTO> GetAllByBrand(int brandId)
        {
            return _productRepo.GetProductsByBrand(brandId);
        }

        public List<ProductListResponseDTO> GetAllByCategory(int categoryId)
        {
            return _productRepo.GetProductsByCategory(categoryId);
        }

        public List<ProductListResponseDTO> GetAllByCategoryAndBrand(int categoryId, int brandId)
        {
            return _productRepo.GetProductsByBrandAndCate(categoryId, brandId);
        }

        public ProductDetailResponseDTO GetProductById(int id)
        {
            return _productRepo.GetProductById(id);
        }

        public bool Update(UpdateProductRequestDTO request)
        {
            return _productRepo.UpdateProduct(new Product
            {
                Id = request.Id,
                BrandId = request.BrandId,
                CategoryId = request.CategoryId,
                IsAvailable = request.IsAvailable,
                UnitsInStock = request.UnitsInStock,
            });
        }
    }
}
