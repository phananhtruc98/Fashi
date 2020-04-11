using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Order: AuditableEntity
    {
        public int UserId { get; set; }
        public User User { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
