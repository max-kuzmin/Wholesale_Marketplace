//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wholesale_Marketplace.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class User
    {
        public User()
        {
            this.Buyers = new HashSet<Buyer>();
            this.Sellers = new HashSet<Seller>();
            this.Support_agent = new HashSet<Support_agent>();
            this.Messages = new HashSet<Message>();
        }
    
        public int UserID { get; set; }
        public int RoleID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
    
        public virtual ICollection<Buyer> Buyers { get; set; }
        public virtual Role Role { get; set; }
        public virtual ICollection<Seller> Sellers { get; set; }
        public virtual ICollection<Support_agent> Support_agent { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
    }
}
