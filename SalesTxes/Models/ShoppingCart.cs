using System;
namespace SalesTxes.Models
{
    public class ShoppingCart
    {
        IDictionary<string, SaleItem> cart = new Dictionary<string, SaleItem>();
        public ShoppingCart()
        {

        }

        public void AddItem(string key, string name, decimal price,int quantity)
        {
            if (this.cart.ContainsKey(key))
            {
                this.cart[key].AddQuantity(quantity);

            } else
            {
                this.cart.Add(key, new SaleItem(quantity, name, price));
            }
        }

        public void PrintReceipt()
        {
            decimal totalTax = 0;
            decimal totalPrice = 0;
            foreach (KeyValuePair<string, SaleItem> kvp in this.cart)
            {
                decimal itemTax = kvp.Value.GetItemTax();
                int itemQuantity = kvp.Value.Quantity;
                string itemName = kvp.Value.Name;
                decimal itemTotalPrice = kvp.Value.GetTotalPriceWithTaxes();
                decimal itemPrice = kvp.Value.Price;

                if (itemQuantity > 1)
                {
                    Console.WriteLine("{0}: {1:N2} ({2} @ {3:N2})", itemName, itemTotalPrice, itemQuantity, itemPrice);
                } else
                {
                    Console.WriteLine("{0}: {1:N2}", itemName, itemTotalPrice);
                }

                totalTax += itemTax;
                totalPrice += itemTotalPrice;
            }
            Console.WriteLine("Sales Taxes: {0:N2}", totalTax);
            Console.WriteLine("Total: {0:N2}", totalPrice);
        }
    }
}

