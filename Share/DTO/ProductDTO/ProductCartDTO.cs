using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTO.ProductDTO
{
    public class ProductCartDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public string? ImgSource { get; set; }
        public int UnitsInStock { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Total { get; set; }
    }
}
