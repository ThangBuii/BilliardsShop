using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Share;
using Share.DTO.ProductImageDTO;
using Share.Models;

namespace Business.Interfaces
{
    public interface IProductImageService
    {
        public List<ProductImage> GetAll();

        public ProductImage Add(AddProductImageDTO request);
        public bool Delete(int id);

        public bool Update(UpdateProductImageDTO request);
    }
}
