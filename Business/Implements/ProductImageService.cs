using Business.Interfaces;
using DataLayer.Interfaces;
using Share.DTO.BrandDTO;
using Share.DTO.ProductImageDTO;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class ProductImageService : IProductImageService
    {
        private readonly IProductImageRepository _productImageRepo;

        public ProductImageService(IProductImageRepository productImageRepo)
        {
            _productImageRepo = productImageRepo;
        }

        public ProductImage Add(AddProductImageDTO request)
        {
            return _productImageRepo.AddProductImage(new ProductImage
            {
                IsMainImage = request.IsMainImage,
                ProductId = request.ProductId,
                Source = request.Source,
            });
        }

        public bool Delete(int id)
        {
            return _productImageRepo.DeleteProductImage(id);
        }

        public List<ProductImage> GetAll()
        {
            return _productImageRepo.GetAllProductImages();
        }

      

        public bool Update(UpdateProductImageDTO request)
        {
            return _productImageRepo.UpdateProductImage(new ProductImage
            {
               Id = request.Id,
               Source = request.Source,
               ProductId = request.ProductId,
               IsMainImage=request.IsMainImage,
            });
        }
    }
}
