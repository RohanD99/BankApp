using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.BankStaff
{
    internal class CurrencyType
    {
        private static Dictionary<string, decimal> currencyExchangeRates = new Dictionary<string, decimal>();
        public static void AddAcceptedCurrency()
        {
            Console.WriteLine("Enter the currency code (e.g., USD, EUR):");
            string currencyCode = Console.ReadLine();

            Console.WriteLine("Enter the exchange rate for 1 unit of the currency:");
            decimal exchangeRate = decimal.Parse(Console.ReadLine());

            currencyExchangeRates[currencyCode] = exchangeRate;

            Console.WriteLine("Accepted currency added successfully.");
        }
    }
}
