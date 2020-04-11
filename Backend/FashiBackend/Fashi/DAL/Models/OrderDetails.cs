using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class OrderDetails : AuditableEntity
    {
        public int OrderId { get; set; }
        public Order Order { get; set; }
        public int Quantity { get; set; }
        public string UnitPrice { get; set; }
        public int PromotionId { get; set; }
        public int ProductDetailsId { get; set; }
        public Promotion Promotion { get; set; }
        public ProductDetails ProductDetails { get; set; }
    }
}
