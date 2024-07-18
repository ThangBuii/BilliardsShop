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
        Product GetProductById(int id);
        List<Product> GetAllProducts();
        List<Product> GetProductsByCategory(int categoryId);
        List<Product> GetProductsByBrand(int brandId);
        bool UpdateProduct(Product product);
        bool DeleteProduct(int id);
    }


}
