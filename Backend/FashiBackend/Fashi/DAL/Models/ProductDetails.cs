using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class ProductDetails: AuditableEntity
    {
        public int ProductId { get; set; }
        public int AttributeId { get; set; }
        public bool IsSaleOff { get;set; }
        public Product Product { get; set; }
        public Attribute Attribute { get; set; }
        public ICollection<CartDetails> CartDetails { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
