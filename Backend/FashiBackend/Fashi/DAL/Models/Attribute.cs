using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Attribute: AuditableEntity
    {
        public string Name { get; set; }
        public string Value { get; set; }
        public ICollection<ProductDetails> ProductDetails { get; set; }
    }
}
