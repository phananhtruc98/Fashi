using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class CartDetails: AuditableEntity
    {
        public int ProductDetailsId { get; set; }
        public ProductDetails ProductDetails { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }

    }
}
