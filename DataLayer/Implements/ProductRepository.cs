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
    public class ProductRepository : IProductRepository
    {
        private readonly PRN231_PROJECT_2Context _context;

        public ProductRepository(PRN231_PROJECT_2Context context)
        {
            _context = context;
        }

        public Product AddProduct(Product product)
        {
            try
            {
                _context.Products.Add(product);
                _context.SaveChanges();
                return product;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool DeleteProduct(int id)
        {
            var product = GetProductById(id);
            if (product == null) return false;
            try
            {
                var productDetail = _context.ProductDetails.FirstOrDefault(x => x.ProductId == id);
                var productImage = _context.ProductImages.FirstOrDefault(x => x.ProductId == id);
                _context.ProductDetails.Remove(productDetail);
                _context.ProductImages.Remove(productImage);
                _context.Products.Remove(product);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<Product> GetAllProducts()
        {
            return _context.Products.ToList();
        }

        public Product GetProductById(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        public List<Product> GetProductsByBrand(int brandId)
        {
            return _context.Products.Where(p => p.BrandId == brandId).ToList();
        }

        public List<Product> GetProductsByCategory(int categoryId)
        {
            return _context.Products.Where(p => p.CategoryId == categoryId).ToList();
        }

        public bool UpdateProduct(Product product)
        {
            var originalProduct = GetProductById(product.Id);
            if (originalProduct == null) return false;

            try
            {
                _context.Attach(product).State = EntityState.Modified;
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
