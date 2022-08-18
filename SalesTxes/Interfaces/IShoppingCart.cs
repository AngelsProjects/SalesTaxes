using System;
namespace SalesTxes.Interfaces
{
    public interface IShoppingCart
    {
        public void AddItem(ISaleItem saleItem);
        public void PrintReceipt();
    }
}
