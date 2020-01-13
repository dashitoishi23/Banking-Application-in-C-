using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_Application
{
    class Bankstaff
    {
        public string EmployeeID { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string BankName { get; set; }
        public string BankID { get; set; }

       public Bankstaff()
        {

        }

        public Bankstaff(string EmployeeID, string BankName, string BankID, string UserID, string Password)
        {
            this.EmployeeID = EmployeeID;
            this.BankName = BankName;
            this.BankID = BankID;
        }
        public Account CreateAccount(string Name, string UserID)
        {
            string AccountID = Name.Substring(0, 3) + DateTime.Now.ToString();
            double  Funds = 0;
            Account account = new Account(UserID, AccountID, Funds);
            return account;
        }
        public Account UpdateAccount(Account account)
        {
            string AccountIDEdited = account.AccountID.Substring(0, 3) + DateTime.Now.ToString();
            account.AccountID = AccountIDEdited;
            return account;

        }
        public Currencies AddCurrency(string Name, int ExchangeRate)
        {
            Currencies currency = new Currencies(Name, ExchangeRate, false);
            return currency;
        }

    }
}
