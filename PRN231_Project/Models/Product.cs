using System;
using System.Collections.Generic;

namespace PRN231_Project.Models
{
    public partial class Product
    {
        public Product()
        {
            OrderDetails = new HashSet<OrderDetail>();
            ProductImages = new HashSet<ProductImage>();
        }

        public int Id { get; set; }
        public int CategoryId { get; set; }
        public int UnitsInStock { get; set; }
        public bool? IsAvailable { get; set; }
        public int BrandId { get; set; }

        public virtual Brand Brand { get; set; } = null!;
        public virtual Category Category { get; set; } = null!;
        public virtual ProductDetail? ProductDetail { get; set; }
        public virtual ICollection<OrderDetail> OrderDetails { get; set; }
        public virtual ICollection<ProductImage> ProductImages { get; set; }
    }
}
