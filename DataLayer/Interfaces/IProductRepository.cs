using Share.DTO.ProductDTO;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IProductRepository
    {
        Product AddProduct(Product product);
        ProductDetailResponseDTO GetProductById(int id);
        List<Product> GetAllProductsAdmin();
        List<ProductListResponseDTO> GetProductsByCategory(int categoryId);
        List<ProductListResponseDTO> GetProductsByBrand(int brandId);
        List<ProductListResponseDTO> GetProductsByBrandAndCate(int brandId,int categoryId);
        List<ProductListResponseDTO> GetAllProducts();

        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }


}
