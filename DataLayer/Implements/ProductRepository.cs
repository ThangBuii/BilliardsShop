using DataLayer.Interfaces;
using Microsoft.EntityFrameworkCore;
using Share.DTO.ProductDTO;
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
            var product = GetProductById1(id);
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

       

        public List<Product> GetAllProductsAdmin()
        {
            return _context.Products.ToList();
        }

        private Product GetProductById1(int id)
        {
            return _context.Products.FirstOrDefault(p => p.Id == id);
        }

        

        public List<ProductListResponseDTO> GetProductsByBrandAndCate(int brandId, int categoryId)
        {
           var list = _context.Products.Include(p => p.ProductDetail).Include(p => p.ProductImages).Select(p => new ProductListResponseDTO
           {
               Id = p.Id,
               ImgSource = p.ProductImages.FirstOrDefault(pi => pi.IsMainImage == true).Source,
               IsAvailable = p.IsAvailable,
               Name = p.ProductDetail.Name,
               BrandId = p.BrandId,
               CategoryId = p.CategoryId,
           }).Where(p => p.BrandId == brandId && p.CategoryId == categoryId).ToList();
            return list;
        }

       

        public bool UpdateProduct(Product product)
        {
            var originalProduct = GetProductById1(product.Id);
            if (originalProduct == null) return false;

            try
            {
                _context.Entry(originalProduct).CurrentValues.SetValues(product);

                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        public List<ProductListResponseDTO> GetAllProducts()
        {
            var list = _context.Products.Include(p => p.ProductDetail).Include(p => p.ProductImages).Select(p => new ProductListResponseDTO
            {
                Id = p.Id,
                ImgSource = p.ProductImages.FirstOrDefault(pi => pi.IsMainImage == true).Source,
                IsAvailable = p.IsAvailable,
                Name = p.ProductDetail.Name,
                BrandId = p.BrandId,
                CategoryId = p.CategoryId,
            }).ToList();
            return list;
        }

        public ProductDetailResponseDTO GetProductById(int id)
        {
            var product =  _context.Products.Include(p => p.ProductDetail).Include(p => p.ProductDetail).Include(p => p.Category).Include(p => p.Brand).Select(p => new ProductDetailResponseDTO
            {
                Id = p.Id,
                BrandName = p.Brand.Name,
                Name = p.ProductDetail.Name,
                ButtLength = p.ProductDetail.ButtLength,
                CategoryName = p.Category.Name,
                Description = p.ProductDetail.Description,
                EraserSize = p.ProductDetail.EraserSize,
                Grip = p.ProductDetail.Grip,
                IsAvailable = p.IsAvailable,
                Price = p.ProductDetail.Price,
                ShaftLength = p.ProductDetail.ShaftLength,
                ShortDescription = p.ProductDetail.ShortDescription,
                UnitsInStock = p.UnitsInStock,
                Weight = p.ProductDetail.Weight,
                ImgSource = p.ProductImages.Select(pi => pi.Source).ToList(),
            }).FirstOrDefault(p => p.Id == id);
            return product;
        }

        public List<ProductListResponseDTO> GetProductsByBrand(int brandId)
        {
            var list = _context.Products.Include(p => p.ProductDetail).Include(p => p.ProductImages).Select(p => new ProductListResponseDTO
            {
                Id = p.Id,
                ImgSource = p.ProductImages.FirstOrDefault(pi => pi.IsMainImage == true).Source,
                IsAvailable = p.IsAvailable,
                Name = p.ProductDetail.Name,
                BrandId = p.BrandId,
                CategoryId = p.CategoryId,
            }).Where(p => p.BrandId == brandId).ToList();
            return list;
        }

        public List<ProductListResponseDTO> GetProductsByCategory(int categoryId)
        {
            var list = _context.Products.Include(p => p.ProductDetail).Include(p => p.ProductImages).Select(p => new ProductListResponseDTO
            {
                Id = p.Id,
                ImgSource = p.ProductImages.FirstOrDefault(pi => pi.IsMainImage == true).Source,
                IsAvailable = p.IsAvailable,
                Name = p.ProductDetail.Name,
                BrandId = p.BrandId,
                CategoryId = p.CategoryId,
            }).Where(p => p.CategoryId == categoryId).ToList();
            return list;
        }
    }

}
