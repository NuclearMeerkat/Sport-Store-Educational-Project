using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class User : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime BirthDate { get; set; }
        public string Login { get; set; } // New attribute for login
        public string PhoneNumber { get; set; } // New attribute for phone number

        // Foreign key for Role
        public int RoleId { get; set; }
        public Role Role { get; set; } // Relationship with Role

        // Navigation property for Orders
        public ICollection<Order> Orders { get; set; }
    }
}
