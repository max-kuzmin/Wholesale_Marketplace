//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан по шаблону.
//
//     Изменения, вносимые в этот файл вручную, могут привести к непредвиденной работе приложения.
//     Изменения, вносимые в этот файл вручную, будут перезаписаны при повторном создании кода.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Wholesale_Marketplace.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_status
    {
        public Order_status()
        {
            this.Order = new HashSet<Order>();
        }
    
        public int Order_status_number { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Order> Order { get; set; }
    }
}