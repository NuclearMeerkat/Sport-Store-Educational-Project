using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Order : BaseEntity
    {
        public DateTime OrderDate { get; set; }
        public bool IsShipped { get; set; }

        // Foreign key for User
        public int UserId { get; set; }
        public User User { get; set; } // Relationship with User

        // Navigation property for OrderItems
        public ICollection<OrderItem> OrderItems { get; set; } 
    }
}
