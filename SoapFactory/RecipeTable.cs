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
    
    public partial class RecipeTable
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public RecipeTable()
        {
            this.SoapTable = new HashSet<SoapTable>();
        }
    
        public int IdRecipe { get; set; }
        public string Name { get; set; }
        public System.DateTime Date { get; set; }
        public int IdIngredient { get; set; }
        public double Quantity { get; set; }
        public string Others { get; set; }
    
        public virtual IngredientTable IngredientTable { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SoapTable> SoapTable { get; set; }
    }
}
