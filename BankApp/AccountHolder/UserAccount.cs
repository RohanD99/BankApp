using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.AccountHolder
{
    internal class UserAccount
    {
        public class Account
        {
            public string HolderName { get; set; }
            public string BankName { get; set; }
            public string BankID { get; set; }
            public string AccountID { get; set; }
            public decimal Balance { get; set; }
            public List<Transaction> TransactionHistory { get; set; }

            public Account(string holderName, string bankName)
            {
                HolderName = holderName;
                BankName = bankName;
                BankID = bankName.Substring(0, 3) + DateTime.Now.ToString("yyyyMMdd");
                AccountID = holderName.Substring(0, 3) + DateTime.Now.ToString("yyyyMMdd");
                Balance = 0;
                TransactionHistory = new List<Transaction>();
            }

            public void Deposit()
            {
                Console.WriteLine("Enter the currency:");
                string currency = Console.ReadLine();

                Console.WriteLine("Enter the amount:");
                decimal amount = decimal.Parse(Console.ReadLine());

                decimal convertedAmount = ConvertCurrencyToINR(currency, amount);

                // Deposit amount
                Balance += convertedAmount;

                string transactionID = "TXN" + BankID + AccountID + DateTime.Now.ToString("yyyyMMddHHmmss");
                Transaction transaction = new Transaction(transactionID, "Deposit", currency, amount, convertedAmount);
                TransactionHistory.Add(transaction);

                Console.WriteLine("Deposit successful. Current balance: " + Balance + " INR");
            }

            public void Withdraw()
            {
                Console.WriteLine("Enter the amount:");
                decimal amount = decimal.Parse(Console.ReadLine());

                if (Balance >= amount)
                {
                    // Withdraw amount
                    Balance -= amount;

                    // Add transaction to history
                    string transactionID = "TXN" + BankID + AccountID + DateTime.Now.ToString("yyyyMMddHHmmss");
                    Transaction transaction = new Transaction(transactionID, "Withdrawal", "INR", amount, amount);
                    TransactionHistory.Add(transaction);

                    Console.WriteLine("Withdrawal successful. Current balance: " + Balance + " INR");
                }
                else
                {
                    Console.WriteLine("Insufficient balance. Withdrawal failed.");
                }
            }

            public void Transfer(Account recipient, decimal amount)
            {
                if (Balance >= amount)
                {
                    // Transfer amount from sender to recipient
                    Balance -= amount;
                    recipient.Balance += amount;

                    // Add transaction to sender's history
                    string transactionID = "TXN" + BankID + AccountID + DateTime.Now.ToString("yyyyMMddHHmmss");
                    Transaction transaction = new Transaction(transactionID, "Transfer", "INR", amount, amount);
                    TransactionHistory.Add(transaction);

                    // Add transaction to recipient's history
                    string recipientTransactionID = "TXN" + recipient.BankID + recipient.AccountID + DateTime.Now.ToString("yyyyMMddHHmmss");
                    Transaction recipientTransaction = new Transaction(recipientTransactionID, "Transfer", "INR", amount, amount);
                    recipient.TransactionHistory.Add(recipientTransaction);

                    Console.WriteLine("Transfer successful. Current balance: " + Balance + " INR");
                }
                else
                {
                    Console.WriteLine("Insufficient balance. Transfer failed.");
                }
            }

            public void ViewYourTransactionHistory()
            {
                Console.WriteLine("Transaction History:");
                foreach (Transaction transaction in TransactionHistory)
                {
                    Console.WriteLine(transaction.ToString());
                }
            }

            private decimal ConvertCurrencyToINR(string currency, decimal amount)
            {
                // Assuming 1 unit of any currency is equal to 100 INR
                if (currency == "INR")
                {
                    return amount;
                }
                else
                {
                    return amount * 100;
                }
            }
        }

        public class Transaction
        {
            public string TransactionID { get; set; }
            public string Type { get; set; }
            public string Currency { get; set; }
            public decimal Amount { get; set; }
            public decimal ConvertedAmount { get; set; }

            public Transaction(string transactionID, string type, string currency, decimal amount, decimal convertedAmount)
            {
                TransactionID = transactionID;
                Type = type;
                Currency = currency;
                Amount = amount;
                ConvertedAmount = convertedAmount;
            }

            public override string ToString()
            {
                return "Transaction ID: " + TransactionID +
                       ", Type: " + Type +
                       ", Currency: " + Currency +
                       ", Amount: " + Amount +
                       ", Converted Amount: " + ConvertedAmount;
            }
        }


        public static void PerformAccountHolderAction(int action)
        {
            Account account = new Account("Holder Name", "Bank Name");
            switch (action)
            {
                case 1:
                    Console.WriteLine("Deposit Amount");
                   // Account account = new Account("Holder Name", "Bank Name");
                    account.Deposit();
                    break;
                case 2:
                    Console.WriteLine("Withdraw Amount");   
                    account.Withdraw();
                    break;
                case 3:
                    Console.WriteLine("Transfer funds ");
                    Account account1 = new Account("Holder Name", "Bank Name");
                    Account account2 = new Account("Holder Name", "Bank Name");
                    account1.Transfer(account2, 100);
                    break;
                case 4:
                    Console.WriteLine("Viewing transaction history!");
                    Account accountss = new Account("Holder Name", "Bank Name");
                    accountss.ViewYourTransactionHistory();
                    break;
                default:
                    Console.WriteLine("Invalid action. Please try again.");
                    break;
            }
        }
    }
        }
    
