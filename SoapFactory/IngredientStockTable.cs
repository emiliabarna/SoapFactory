//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace SoapFactory
{
    using System;
    using System.Collections.Generic;
    
    public partial class IngredientStockTable
    {
        public int TransactionNumber { get; set; }
        public int IdIngredient { get; set; }
        public System.DateTime Date { get; set; }
        public System.DateTime DateOfBestUse { get; set; }
        public string Producer { get; set; }
        public double Quantity { get; set; }
        public Nullable<double> Price { get; set; }
        public string Others { get; set; }
    
        public virtual IngredientTable IngredientTable { get; set; }
    }
}
