using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Category: AuditableEntity
    {
        public int ParentId { get; set; }
        public Category ParentCategory { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool Active { get; set; }

        public ICollection<ProductCategory> ProductCategories { get; set; }
    }
}
