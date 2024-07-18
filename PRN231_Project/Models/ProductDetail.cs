using System;
using System.Collections.Generic;

namespace PRN231_Project.Models
{
    public partial class ProductDetail
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

        public virtual Product Product { get; set; } = null!;
    }
}
