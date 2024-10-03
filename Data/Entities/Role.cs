using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Entities
{
    public class Role : BaseEntity
    {
        public string RoleName { get; set; }

        // Navigation property for Users
        public ICollection<User> Users { get; set; }
    }
}
