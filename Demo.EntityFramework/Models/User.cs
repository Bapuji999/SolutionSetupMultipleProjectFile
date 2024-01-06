using System;
using System.Collections.Generic;

namespace Demo.EntityFramework.Models
{
    public partial class User
    {
        public User()
        {
            ProductsNavigation = new HashSet<Product>();
            Products = new HashSet<Product>();
        }

        public int UserId { get; set; }
        public string UserName { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Email { get; set; } = null!;
        public int RollId { get; set; }
        public bool IsActive { get; set; }
        public string Password { get; set; } = null!;

        public virtual ICollection<Product> ProductsNavigation { get; set; }

        public virtual ICollection<Product> Products { get; set; }
    }
}
