using System;
using System.IO;
using SalesTxes;
using SalesTxes.Models;
using static System.Net.Mime.MediaTypeNames;

public class Program
{
    public static void Main()
    {
        Console.Clear();

        string itemString;
        ShoppingCart cart = new ShoppingCart();

        do
        {
            itemString = Console.ReadLine();

            if (String.IsNullOrWhiteSpace(itemString))
            {
                continue;
            }

            string[] split = itemString.Split(" ");
            if (split.Length < 3)
            {
                Console.WriteLine($"Unable to parse '{itemString}'");
                Environment.Exit(0);
            }

            try
            {
                int quantity = 0;
                decimal price = 0;
                string name = "";
                string key = string.Join(string.Empty, split.Skip(1)).ToLower();
                for (int i = 0; i < split.Length; i++)
                {
                    if (i == 0)
                    {
                        quantity = Int32.Parse(split[i]);
                        continue;
                    }
                    else if (i == split.Length - 1)
                    {
                        price = Convert.ToDecimal(split[i]);
                        continue;
                    }
                    if (String.IsNullOrEmpty(name))
                    {
                        name = split[i];
                    }
                    else if (i != split.Length - 2)
                    {
                        name += $" {split[i]}";
                    }
                }
                cart.AddItem(key, name, price, quantity);
            }
            catch (FormatException)
            {
                Console.WriteLine($"Unable to parse '{itemString}'");
                Environment.Exit(0);
            }

        } while (!String.IsNullOrWhiteSpace(itemString));
        cart.PrintReceipt();
    }
}
