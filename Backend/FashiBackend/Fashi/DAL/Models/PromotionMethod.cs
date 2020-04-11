using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class PromotionMethod: AuditableEntity
    {
        public string Name { get; set; }
        public ICollection<Promotion> Promotions { get; set; }
    }
}
