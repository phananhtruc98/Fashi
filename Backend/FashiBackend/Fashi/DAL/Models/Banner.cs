using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class Banner: AuditableEntity
    {
        public string Name { get; set; }
        public bool Active { get; set; }
    }
}
