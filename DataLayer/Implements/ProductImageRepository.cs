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
    public class ProductImageRepository : IProductImageRepository
    {
        private readonly PRN231_PROJECT_2Context _context;

        public ProductImageRepository(PRN231_PROJECT_2Context context)
        {
            _context = context;
        }

        public ProductImage AddProductImage(ProductImage productImage)
        {
            try
            {
                _context.ProductImages.Add(productImage);
                _context.SaveChanges();
                return productImage;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool DeleteProductImage(int id)
        {
            var productImage = GetProductImageById(id);
            if (productImage == null) return false;
            try
            {
                _context.ProductImages.Remove(productImage);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<ProductImage> GetAllProductImages()
        {
            return _context.ProductImages.ToList();
        }

        public ProductImage GetProductImageById(int id)
        {
            return _context.ProductImages.FirstOrDefault(pi => pi.Id == id);
        }

        public bool UpdateProductImage(ProductImage productImage)
        {
            var originalProductImage = GetProductImageById(productImage.Id);
            if (originalProductImage == null) return false;

            try
            {
                _context.Entry(originalProductImage).CurrentValues.SetValues(productImage);

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
