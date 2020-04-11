using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Address: AuditableEntity
    {
        public string Name { get; set; }
        public string Ward { get; set; }
        public string District { get; set; }
        public string City { get; set; }
        public string Country { get; set; }
        public bool Active { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
    }
}
