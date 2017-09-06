using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapFactory
{
    public partial class SoapStockTable
    {
        public float Profit
        {
            get
            {
                return (float)this.SellingPrice - this.SoapTable.Price;
            }

        }
    }
}
