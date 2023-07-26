using BankApp.Views;
using System;
using System.Collections.Generic;

namespace BankApp.BankStaff
{
    internal class CurrencyServices
    {
        private static Dictionary<string, decimal> acceptedCurrencies = new Dictionary<string, decimal>()
        {
            { "INR", 1 },
            { "USD", 0.014m },
            { "EUR", 0.012m },
        };

        public static void AddAcceptedCurrency()
        {
            BankView.DisplayCurrencyCode();                         //1
            string currencyCode = Console.ReadLine().ToUpper();

            BankView.DisplayExchangeRate();                           //2
            decimal exchangeRate = decimal.Parse(Console.ReadLine());
        
            acceptedCurrencies.Add(currencyCode, exchangeRate);
            BankView.DisplayCurrencyAdded();


        }

        public static Dictionary<string, decimal> GetAcceptedCurrencies()
        {
            return acceptedCurrencies;
        }
    }
}
