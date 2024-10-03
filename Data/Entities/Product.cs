using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Product : BaseEntity
    {
        public string ProductName { get; set; }
        public decimal Price { get; set; }

        // Foreign key for ProductCategory
        public int ProductCategoryId { get; set; }
        public ProductCategory ProductCategory { get; set; } // Relationship with ProductCategory

        // Navigation property for OrderItems
        public ICollection<OrderItem> OrderItems { get; set; } 
    }
}
