using Share.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataLayer.Interfaces
{
    public interface ICategoryRepository
    {
        Category AddCategory(Category category);
        Category GetCategoryById(int id);
        List<Category> GetAllCategories();
        bool UpdateCategory(Category category);
        bool DeleteCategory(int id);
    }
}
