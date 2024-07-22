using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Share.DTO.OrderDetailDTO
{
    public class OrderDetailListResponseDTO
    {
        public int Id { get; set; }
        public int OrderId { get; set; }    
        public string? ProductName { get; set; }
        public string? ImgSource { get; set; }
        public int Quantity { get; set; }
        public double UnitPrice { get; set; }
        public double TotalPrice { get; set; }
    }
}
