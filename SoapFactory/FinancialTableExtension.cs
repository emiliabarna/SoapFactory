using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoapFactory
{
    public partial class FinancialTable
    {
        public float FinancialPositionProperty { get
            {
                if (this.IsSelling == false){
                    this.FinancialPosition -= this.Amount;}
                else
                {
                    this.FinancialPosition += this.Amount;
                }
                return (float)FinancialPosition;
            }
        }
    }
}
