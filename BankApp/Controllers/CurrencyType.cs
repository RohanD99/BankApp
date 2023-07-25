using System;
using System.Collections.Generic;

namespace BankApp.BankStaff
{
    internal class CurrencyType
    {
        private static Dictionary<string, decimal> acceptedCurrencies = new Dictionary<string, decimal>()
        {
            { "INR", 1 },
            { "USD", 0.014m },
            { "EUR", 0.012m },
        };

        public static void AddAcceptedCurrency()
        {
            Console.WriteLine("Enter the currency code:");
            string currencyCode = Console.ReadLine().ToUpper();

            Console.WriteLine("Enter the exchange rate:");
            decimal exchangeRate = decimal.Parse(Console.ReadLine());

            if (acceptedCurrencies.ContainsKey(currencyCode))
            {
                Console.WriteLine("Currency already exists. Updating exchange rate...");
                acceptedCurrencies[currencyCode] = exchangeRate;
            }
            else
            {
                acceptedCurrencies.Add(currencyCode, exchangeRate);
                Console.WriteLine("Currency added successfully.");
            }
        }

        public static Dictionary<string, decimal> GetAcceptedCurrencies()
        {
            return acceptedCurrencies;
        }
    }
}
