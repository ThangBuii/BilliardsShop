using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTO.ProductDetailDTO
{
    public class UpdateProductDetailDTO
    {
        public int ProductId { get; set; }
        public string Name { get; set; } = null!;
        public double Price { get; set; }
        public string Description { get; set; } = null!;
        public string ShortDescription { get; set; } = null!;
        public double Weight { get; set; }
        public double EraserSize { get; set; }
        public double ButtLength { get; set; }
        public double ShaftLength { get; set; }
        public string Grip { get; set; } = null!;

    }
}
