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
    
    public partial class Item
    {
        public Item()
        {
            this.Order = new HashSet<Order>();
            this.Picture = new HashSet<Picture>();
        }
    
        public int Item_number { get; set; }
        public int Store_number { get; set; }
        public Nullable<int> Category_number { get; set; }
        public string Name { get; set; }
        public Nullable<int> Price { get; set; }
        public string Description { get; set; }
        public Nullable<int> Orders_count { get; set; }
        public Nullable<int> Reviews_count { get; set; }
        public Nullable<int> Positive_marks { get; set; }
        public Nullable<int> Negative_marks { get; set; }
        public Nullable<int> Minimum_order { get; set; }
        public Nullable<System.DateTime> Open_date { get; set; }
        public Nullable<System.DateTime> Close_date { get; set; }
        public Nullable<int> Left_goods_count { get; set; }
    
        public virtual Item_category Item_category { get; set; }
        public virtual Store Store { get; set; }
        public virtual ICollection<Order> Order { get; set; }
        public virtual ICollection<Picture> Picture { get; set; }
    }
}
