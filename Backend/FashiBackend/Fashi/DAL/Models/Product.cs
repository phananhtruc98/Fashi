using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Product: AuditableEntity
    {
        public string Name { get; set; }
        public string Price { get; set; }
        public string Description { get; set; }
        public string Summary { get; set; }
        public bool Active { get; set; }
        
        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
