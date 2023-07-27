using System;
using System.Collections.Generic;
using System.Linq;

namespace BankApplication.Common
{
    internal class Utility
    {
        public static void GenerateOptions(List<string> options)
        {
            foreach (var item in options.Select((value, index) => new { index, value }))
            {
                Console.WriteLine($"{item.index} {item.value}");
            }
        }

        public static string ReadStringInput(string type, bool isRequired)
        {
            string input = string.Empty;
            try
            {
                input = Console.ReadLine();
                if (isRequired && string.IsNullOrEmpty(input))
                {
                    Console.WriteLine($"Please provide valid {type}.");
                    input = ReadStringInput(type, isRequired);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Please provide valid {type}.");
                input = ReadStringInput(type, isRequired);
            }

            return input;
        }

        public static string GenerateBankId(string bankName)
        {
            string currentDate = DateTime.Now.ToString("yyyyMMdd");
            return bankName.Substring(0, 3) + currentDate;
        }

        public static string GenerateEmployeeID()
        {
            return $"Employee_{DateTime.Now.ToString()}";
        }

        public static string GenerateUserID()
        {
            return $"User_{DateTime.Now.ToString()}";
        }

        public static string GenerateTransactionID()
        { 
            return $"TXN_{DateTime.Now:yyyyMMddHHmmssfff}";
        }

        public static string GenerateAccountNumber()
        {
            Random random = new Random();
            return random.Next(100000000, 999999999).ToString();
        }
    }
}
