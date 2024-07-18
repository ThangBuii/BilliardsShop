using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IProductImageRepository
    {
        ProductImage AddProductImage(ProductImage productImage);
        ProductImage GetProductImageById(int id);
        List<ProductImage> GetAllProductImages();
        bool UpdateProductImage(ProductImage productImage);
        bool DeleteProductImage(int id);
    }

}
