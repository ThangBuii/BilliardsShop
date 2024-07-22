using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Share;
using Share.DTO.ProductDetailDTO;
using Share.Models;

namespace Business.Interfaces
{
    public interface IProductDetailService
    {
        public List<ProductDetail> GetAll();

        public ProductDetail Add(AddProductDetailDTO request);
        public bool Delete(int id);

        public bool Update(UpdateProductDetailDTO request);
    }
}
