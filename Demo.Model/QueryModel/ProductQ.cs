using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Model.QueryModel
{
    public class ProductQ
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public double Price { get; set; }
        public string ImagePath { get; set; }
        public int VendorId { get; set; }
        public string CategoryName { get; set; }
        public int CategoryId { get; set; }
        public string VendorName { get; set; }
        public double Rating { get; set; }
    }
}
