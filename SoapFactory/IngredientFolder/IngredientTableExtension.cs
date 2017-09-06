using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapFactory
{
    public partial class IngredientTable
    {
        public float Price
        {
            get
            {
                return this.IngredientStockTable.Sum(x => (float)x.Price);
            }
        } 
    }
}
