using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTO.ProductDTO
{
    public class ProductDetailResponseDTO
    {
        public int Id { get; set; }
        public string? CategoryName { get; set; }
        public int UnitsInStock { get; set; }
        public bool? IsAvailable { get; set; }
        public string? BrandName { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public double Weight { get; set; }
        public double EraserSize { get; set; }
        public double ButtLength { get; set; }
        public double ShaftLength { get; set; }
        public string Grip { get; set; } = null!;
        public List<string> ImgSource { get; set; } = null!;
    }
}
