//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ModelFirst
{
    using System;
    using System.Collections.Generic;
    
    public partial class OrderDetails
    {
        public int orderID { get; set; }
        public int ItemID { get; set; }
        public int productID { get; set; }
        public int purchasedQty { get; set; }
        public string purchasePrice { get; set; }
        public double purchaseAmount { get; set; }
    
        public virtual Product Product { get; set; }
        public virtual Order Order { get; set; }
    }
}