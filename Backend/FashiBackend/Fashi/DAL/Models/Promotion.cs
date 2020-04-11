using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Promotion: AuditableEntity
    {
        public string Name { get; set; }
        public int PromotionMethodId { get; set; }
        public string Description { get; set; }
        public ICollection<OrderDetails> OrderDetails { get; set; }
        public PromotionMethod PromotionMethod { get; set; }
    }
}
