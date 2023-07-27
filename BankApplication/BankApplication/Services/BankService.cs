
using BankApplication.Common;
using BankApplication.Models;

namespace BankApplication.Services
{
    internal class BankService
    {
        public Response CreateBank(Bank bank)
        {
            Response response = new Response();
            try
            {
                bank.Id = Utility.GenerateBankId(bank.BankName);
                DataStorage.Banks.Add(bank);
                response.IsSuccess = true;
                response.Message = "Bank created successfully.";
                response.Data = bank.Id;
            }
            catch
            {
                response.IsSuccess = false;
                response.Message = "Bank creation failed.";
            }
            return response;
           
        }
    }
}
