using System;

namespace BankApplication.Models
{
    internal class Response
    {
        public bool IsSuccess { get; set; }

        public string Message { get; set; }

        public string Data { get; set; }

        public void PrintMessage()
        {
            Console.WriteLine(Message);
        }
    }


}
