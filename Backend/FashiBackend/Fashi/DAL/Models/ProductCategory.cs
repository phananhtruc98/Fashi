using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class ProductCategory: AuditableEntity
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public Product Product { get; set; }
    }
}
