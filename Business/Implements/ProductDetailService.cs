using Business.Interfaces;
using DataLayer.Interfaces;
using Share.DTO.ProductDetailDTO;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class ProductDetailService : IProductDetailService
    {
        private readonly IProductDetailRepository _productDetailRepo;

        public ProductDetailService(IProductDetailRepository productDetailRepo)
        {
            _productDetailRepo = productDetailRepo;
        }

       

        public ProductDetail Add(AddProductDetailDTO request)
        {
            return _productDetailRepo.AddProductDetail(new ProductDetail
            {
                ButtLength = request.ButtLength,
                Description = request.Description,
                EraserSize = request.EraserSize,
                Grip = request.Grip,
                Name = request.Name,
                Price = request.Price,
                ProductId = request.ProductId,
                ShaftLength = request.ShaftLength,
                ShortDescription = request.ShortDescription,
                Weight = request.Weight,
            });
        }

        public bool Delete(int id)
        {
            return _productDetailRepo.DeleteProductDetail(id);
        }

        public List<ProductDetail> GetAll()
        {
            return _productDetailRepo.GetAllProductDetails();
        }



        public bool Update(UpdateProductDetailDTO request)
        {
            return _productDetailRepo.UpdateProductDetail(new ProductDetail
            {
                ButtLength = request.ButtLength,
                Description = request.Description,
                EraserSize = request.EraserSize,
                Grip = request.Grip,
                Name = request.Name,
                Price = request.Price,
                ProductId = request.ProductId,
                ShaftLength = request.ShaftLength,
                ShortDescription = request.ShortDescription,
                Weight = request.Weight,
            });
        }
    }
}
