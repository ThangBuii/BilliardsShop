using Share.DTO.OrderDTO;
using Share.DTO.ProductDTO;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Interfaces
{
    public interface IProductService
    {
        public List<ProductListResponseDTO> GetAll();

        public Product Add(AddProductRequestDTO request);
        public bool Delete(int id);

        public bool Update(UpdateProductRequestDTO request);

        public ProductDetailResponseDTO GetProductById(int id);
        public List<ProductListResponseDTO> GetAllByCategory(int categoryId);  
        public List<ProductListResponseDTO> GetAllByBrand(int brandId);
        public List<ProductListResponseDTO> GetAllByCategoryAndBrand(int categoryId, int brandId);
        public List<Product> GetAllAdmin();
    }
}
