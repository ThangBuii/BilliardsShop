using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface IBrandRepository
    {
        public Brand AddBrand(Brand brand);

        
        public Brand GetBrandById(int id);

      
        public List<Brand> GetAllBrands();

        public bool UpdateBrand(Brand brand);

        public bool DeleteBrand(int id);
    }
}
