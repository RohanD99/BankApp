using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.SetupNewBank
{
    internal class StaffMember
    {
        public string Username { get; set; }
        public string Password { get; set; }

        public StaffMember(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
