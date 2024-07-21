using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTO.ProductDTO
{
    public class ProductListResponseDTO
    {
        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public int BrandId { get; set; }
        public int CategoryId { get; set; }
        public string ImgSource { get; set; } = null!;
        public bool? IsAvailable { get; set; }
    }
}
