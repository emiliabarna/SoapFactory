﻿//------------------------------------------------------------------------------
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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class SoapFactoryEntities : DbContext
    {
        public SoapFactoryEntities()
            : base("name=SoapFactoryEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<IngredientStockTable> IngredientStockTable { get; set; }
        public virtual DbSet<IngredientTable> IngredientTable { get; set; }
        public virtual DbSet<RecipeTable> RecipeTable { get; set; }
        public virtual DbSet<SoapStockTable> SoapStockTable { get; set; }
        public virtual DbSet<SoapTable> SoapTable { get; set; }
        public virtual DbSet<FinancialTable> FinancialTable { get; set; }
    }
}
