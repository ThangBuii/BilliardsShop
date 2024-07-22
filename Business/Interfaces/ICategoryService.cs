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
    public interface ICategoryService
    {
        List<Category> GetAll();

        Category AddCategory(AddCategoryRequestDTO request);

        bool DeleteCategory(int id);

        bool UpdateCategory(EditCategoryRequestDTO request);
        Category GetById(int id);
    }
}
