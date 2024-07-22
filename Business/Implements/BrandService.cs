using Business.Interfaces;
using DataLayer.Interfaces;
using Share.DTO.BrandDTO;
using Share.Models;

namespace Business.Implements
{
    public class BrandService : IBrandService
    {
        private readonly IBrandRepository _brandRepository;

        public BrandService(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }

        public Brand AddBrand(AddBrandRequestDTO request)
        {

            return _brandRepository.AddBrand(new Brand { Name = request.Name});
        }

        public bool DeleteBrand(int id)
        {
            return _brandRepository.DeleteBrand(id);
        }

        public List<Brand> GetAll()
        {
            return _brandRepository.GetAllBrands();
        }

        public Brand GetById(int id)
        {
            return _brandRepository.GetBrandById(id);
        }

        public bool UpdateBrand(EditBrandRequestDTO request)
        {
            return _brandRepository.UpdateBrand(new Brand { Id = request.Id,Name = request.Name });
        }
    }
}
