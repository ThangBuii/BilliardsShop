using Business.Interfaces;
using DataLayer.Interfaces;
using Share.DTO.BrandDTO;
using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Implements
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public Category AddCategory(AddCategoryRequestDTO request)
        {
            return _categoryRepository.AddCategory(new Category { Name = request.Name });
        }

        public bool DeleteCategory(int id)
        {
            return _categoryRepository.DeleteCategory(id);
        }

        public List<Category> GetAll()
        {
            return _categoryRepository.GetAllCategories();
        }

        public bool UpdateCategory(EditCategoryRequestDTO request)
        {
            return _categoryRepository.UpdateCategory(new Category { Id = request.Id, Name = request.Name });
        }
    }

}
