using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Implements
{
    public class ProductDetailRepository : IProductDetailRepository
    {
        private readonly PRN231_PROJECT_2Context _context;

        public ProductDetailRepository(PRN231_PROJECT_2Context context)
        {
            _context = context;
        }

        public ProductDetail AddProductDetail(ProductDetail productDetail)
        {
            try
            {
                _context.ProductDetails.Add(productDetail);
                _context.SaveChanges();
                return productDetail;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool DeleteProductDetail(int id)
        {
            var productDetail = GetProductDetailById(id);
            if (productDetail == null) return false;
            try
            {
                _context.ProductDetails.Remove(productDetail);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<ProductDetail> GetAllProductDetails()
        {
            return _context.ProductDetails.ToList();
        }

        public ProductDetail GetProductDetailById(int id)
        {
            return _context.ProductDetails.FirstOrDefault(pd => pd.ProductId == id);
        }

        public bool UpdateProductDetail(ProductDetail productDetail)
        {
            var originalProductDetail = GetProductDetailById(productDetail.ProductId);
            if (originalProductDetail == null) return false;

            try
            {
                _context.Entry(originalProductDetail).CurrentValues.SetValues(productDetail);

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }
    }
}
