using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class UserType: AuditableEntity
    {
        public string Name { get; set; }
        public ICollection<User> Users { get; set; }
    }
}
