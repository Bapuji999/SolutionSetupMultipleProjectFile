using System;
using System.Collections.Generic;

namespace Demo.EntityFramework.Models
{
    public partial class Product
    {
        public Product()
        {
            Customers = new HashSet<User>();
        }

        public int ProductId { get; set; }
        public string ProductName { get; set; } = null!;
        public double Price { get; set; }
        public string ImagePath { get; set; } = null!;
        public int VendorId { get; set; }
        public int CategoryId { get; set; }
        public double Rating { get; set; }

        public virtual Category Category { get; set; } = null!;
        public virtual User Vendor { get; set; } = null!;

        public virtual ICollection<User> Customers { get; set; }
    }
}
