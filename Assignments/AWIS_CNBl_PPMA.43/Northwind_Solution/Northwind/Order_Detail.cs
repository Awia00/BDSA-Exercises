//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Northwind
{
    using System;
    using System.Collections.Generic;
    
    public partial class Order_Detail
    {
        public int OrderID { get; set; }
        public int ProductID { get; set; }
        public decimal UnitPrice { get; set; }
        public short Quantity { get; set; }
        public float Discount { get; set; }
    
        public Order Order { get; set; }
        public Product Product { get; set; }

        public Order_Detail(int orderId, int productId, decimal unitPrice, short quantity, float discount, Product product)
        {
            OrderID = orderId;
            ProductID = productId;
            UnitPrice = unitPrice;
            Quantity = quantity;
            Discount = discount;
            Product = product;
        }

        public Order_Detail()
        {
            
        }

        public override string ToString()
        {
            return "Order details\n      ID: " + OrderID +
                "\n      Product: " + Product +
                "\n      Unit Price: " + UnitPrice +
                "\n      Quantity: " + Quantity +
                "\n      Discount: " + Discount;
        }
    }
}
