namespace BankApplication.Common
{
    public class Enums
    {
        public enum MainMenuOption
        {
            CreateNewBank,
            LoginAsAccountHolder,
            LoginAsBankStaff,
            Exit
        }

        public enum BankStaffOption
        {
            CreateNewAccountAndProvideUsernameAndPasswordToAccountHolder,
            UpdateAccount,
            DeleteAccount,
            ShowAllAccounts,
            AddNewAcceptedCurrencyWithExchangeRate,
            AddServiceChargeForSameBankAccount,
            AddServiceChargeForOtherBankAccount,
            ViewAccountTransactionHistory,
            RevertAnyTransaction,
            GoBackToStart
        }

        public enum UserAccountOption
        {
            DepositAmount,                
            WithdrawAmount,
            TransferFunds,
            CheckBalance,
            ViewTransactionHistory,
            GoBackToStart
        }

        public enum UserType
        {
            Admin,
            Employee,
            AccountHolder
        }
    }
}
