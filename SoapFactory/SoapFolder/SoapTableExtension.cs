using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapFactory
{
    public partial class SoapTable
    {
        SoapFactoryEntities se = new SoapFactoryEntities();
        public float Price
        {
            get
            {
                
                float quantity = (float)this.RecipeTable.Quantity;
                IngredientTable ingSearched = se.IngredientTable.Where(x => (x.IdIngredient == this.RecipeTable.IdIngredient)).First();
                float fullPrice = ingSearched.Price;
                if ((se.IngredientStockTable.Where(x => (x.IdIngredient == ingSearched.IdIngredient)).First()) != null)
                   { IngredientStockTable ingS = se.IngredientStockTable.Where(x => (x.IdIngredient == ingSearched.IdIngredient)).First();
                    float quantityOfSoap = (float)ingS.Quantity;
                    return (float)(fullPrice / quantityOfSoap * this.RecipeTable.Quantity);
                }
                else
                { return 0; }
            }
        }
    }
}
