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
    public class BrandRepository : IBrandRepository
    {
        private readonly PRN231_PROJECT_2Context _context;

        public BrandRepository(PRN231_PROJECT_2Context context)
        {
            _context = context;
        }

        public Brand AddBrand(Brand brand)
        {
            try
            {
                _context.Brands.Add(brand);
                _context.SaveChanges();
                return brand;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        public bool DeleteBrand(int id)
        {
            var brand = GetBrandById(id);
            if (brand == null) return false;
            try
            {
                _context.Brands.Remove(brand);
                _context.SaveChanges();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }

        }

        public List<Brand> GetAllBrands()
        {
            var list = _context.Brands.ToList();
            return list;
        }

        public Brand GetBrandById(int id)
        {
            var brand = _context.Brands.FirstOrDefault(b => b.Id == id);
            if(brand == null)
            {
                return null;
            }
            return brand;
        }

        public bool UpdateBrand(Brand brand)
        {
            var originalBrand = GetBrandById(brand.Id);
            if(originalBrand == null) return false;
            _context.Attach(brand).State = EntityState.Modified;
            _context.SaveChanges();

            return false;
        }
    }
}
