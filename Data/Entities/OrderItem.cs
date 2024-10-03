using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class OrderItem : BaseEntity
    {
        public decimal UnitPrice { get; set; }
        public int Quantity { get; set; }

        // Foreign key for Order
        public int OrderId { get; set; }
        public Order Order { get; set; } // Relationship with Order

        // Foreign key for Product
        public int ProductId { get; set; }
        public Product Product { get; set; } // Relationship with Product
    }
}
