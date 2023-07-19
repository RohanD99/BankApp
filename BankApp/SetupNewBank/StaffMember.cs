using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankApp.SetupNewBank
{
    internal class StaffMember
    {
        public string Username { get; private set; }
        public string Password { get; private set; }

        public StaffMember(string username, string password)
        {
            Username = username;
            Password = password;
        }
    }
}
