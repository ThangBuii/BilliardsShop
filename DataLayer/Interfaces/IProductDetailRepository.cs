using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IProductDetailRepository
    {
        ProductDetail AddProductDetail(ProductDetail productDetail);
        ProductDetail GetProductDetailById(int id);
        List<ProductDetail> GetAllProductDetails();
        bool UpdateProductDetail(ProductDetail productDetail);
        bool DeleteProductDetail(int id);
    }


}
