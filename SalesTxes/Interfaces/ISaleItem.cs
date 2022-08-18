using System;
namespace SalesTxes.Interfaces
{
    public interface ISaleItem
    {
        public string Name
        {
            get;
        }

        public int Quantity
        {
            get;
        }

        public decimal GetTotalPrice();

        public decimal GetTotalPriceWithTaxes();

        public decimal GetItemTax();
    }
}
