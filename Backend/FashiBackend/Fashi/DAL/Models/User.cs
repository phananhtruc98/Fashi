using DAL.Core;
using DAL.Models.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Models
{
    public class User: AuditableEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public Gender Gender { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public string DayOfBirth { get; set; }
        public string MobileNumber { get; set; }
        public bool Active { get; set; }
        public int CartId { get; set; }
        public Cart Cart { get; set; }
        public int UserTypeId { get; set; }
        public ICollection<Address> Addresses { get; set; }
        public ICollection<Order> Orders { get; set; }
        public UserType UserType { get; set; }
    }
}
