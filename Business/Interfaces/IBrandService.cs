using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Share;
using Share.DTO.BrandDTO;
using Share.Models;

namespace Business.Interfaces
{
    public interface IBrandService
    {
        public List<Brand> GetAll();

        public Brand AddBrand(AddBrandRequestDTO request);
        public bool DeleteBrand(int id);

        public bool UpdateBrand(EditBrandRequestDTO request);
        public Brand GetById(int id);
    }
}
