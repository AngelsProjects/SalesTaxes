using System;
using System.Linq;
using SalesTxes.Constants;
using SalesTxes.Interfaces;

namespace SalesTxes.Models
{
    public class SaleItem: ISaleItem
    {
        private string name;
        private decimal price;
        private int quantity;

        public SaleItem(int quantity, string name, decimal price)
        {
            #region Parameter Checking
            if (String.IsNullOrWhiteSpace(name))
                throw new ArgumentException("name");
            if (price <= 0)
                throw new ArgumentException("price");
            if (quantity <= 0)
                throw new ArgumentException("quantity");
            #endregion

            this.quantity = quantity;
            this.name = name;
            this.price = price;
        }

        #region ISalesItem Methods

        public string Name
        {
            get { return this.name; }
        }

        public int Quantity
        {
            get { return this.quantity; }
        }

        public decimal Price
        {
            get { return this.price; }
        }

        public decimal GetTotalPrice()
        {
            return this.price * this.quantity;
        }

        public decimal GetItemTax()
        {
            string lowercaseName = name.ToLower();

            decimal totalTax = Taxes.Basic;

            if (ExceptionItems.Words.Any(lowercaseName.Contains))
            {
                totalTax = Taxes.None;
            }

            if (lowercaseName.Contains("imported"))
            {
                totalTax += Taxes.Imported;
            }

            totalTax *= this.GetTotalPrice();

            decimal inverse = 1 / 0.05M;

            totalTax = Math.Ceiling(totalTax * inverse) / inverse;
            
            return totalTax;
        }

        public decimal GetTotalPriceWithTaxes()
        {
            return this.GetTotalPrice() + this.GetItemTax();
        }

        public void AddQuantity(int quantity)
        {
            this.quantity += quantity;
        }

        #endregion
    }
}
