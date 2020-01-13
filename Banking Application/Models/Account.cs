using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_Application
{
    class Account
    {
        public string UserID;
        public string AccountID;
        public double Funds;

        public Account(string UserID, string AccountID, double Funds)
        {
            this.UserID = UserID;
            this.AccountID = AccountID;
            this.Funds = Funds;
        }
    }
}
