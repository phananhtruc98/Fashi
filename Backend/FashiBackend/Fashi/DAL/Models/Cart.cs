using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Cart : AuditableEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<CartDetails> CartDetails{ get; set; }
    }
}
