using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking_Application
{
    class AccountHolder
    {
        public string AccountID { get; set; }
        public string BankID { get; set; }
        public double Funds { get; set; }
        public string UserID { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }
        public string Contact { get; set; }
        public List<Transactions> Transactions = new List<Transactions>();
        public List<Account> Accounts = new List<Account>();


        public AccountHolder(string UserID, string Password)
        {
            this.UserID = UserID;
            this.Password = Password;
        }

        public AccountHolder(string AccountID, string BankID, double Funds, string UserID, string Password, string Name, string Address, string Contact)
        {
            this.AccountID = AccountID;
            this.BankID = BankID;
            this.Funds = Funds;
            this.UserID = UserID;
            this.Password = Password;
            this.Name = Name;
            this.Address = Address;
            this.Contact = Contact;

        }
        public double DepositAmount(double FundsToDeposit)
        {
            Funds += FundsToDeposit;
            Console.WriteLine("Funds deposited succesfully!");
            return Funds;
        }

        public double WithdrawAmount(double FundsToWithdraw)
        {
            if (Funds < FundsToWithdraw)
            {
                return 0;
            }

            Funds -= FundsToWithdraw;
            return Funds;
        }

        
        public void TransferFunds(double AmountToTranfer, string ToAccountID, string BankID)
        {
            if (Funds < AmountToTranfer)
            {
                Console.WriteLine("Insufficient Funds");
            }

            Funds -= AmountToTranfer;
            string TransactionID = "TXN" + DateTime.Now.ToString();
            Transactions transactionToAdd = new Transactions(TransactionID, DateTime.Now, Funds, this.AccountID, ToAccountID);
            this.Transactions.Add(transactionToAdd);
            Console.WriteLine("Successful");

        }
        public List<Transactions> viewTransactions()
        {
            return this.Transactions;
        }

    }
}
