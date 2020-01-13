using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_Application
{
    class Bank
    {
        public double IMPSOwnBank;
        public double RTGSOwnBank;
        public double IMPSOtherBank;
        public double RTGSOtherBank;
        public string BankID;
        public string BankName;
        public List<AccountHolder> AccountHolders = new List<AccountHolder>();
        public List<Currencies> Currencies = new List<Currencies>();
        public List<Bankstaff> BankStaffs = new List<Bankstaff>();
        public List<Transactions> Transactions = new List<Transactions>();
        public List<Account> Accounts = new List<Account>();

        public Bank()
        {
            this.BankID = $"{BankName.Substring(0, 3)}{DateTime.Now.ToString()}";

        }
        public Bank(double IMPSOwnBank, double RTGSOwnBank, double IMPSOtherBank, double RTGSOtherBank, string BankName, Currencies currency)
        {
        this.IMPSOwnBank = IMPSOwnBank;
            this.RTGSOwnBank = RTGSOwnBank;
            this.IMPSOwnBank = IMPSOtherBank;
            this.RTGSOwnBank = RTGSOtherBank;
            this.BankName = BankName;  
            this.BankID = $"{BankName.Substring(0, 3)}{DateTime.Now.ToString()}";
            this.Currencies.Add(currency);
            Console.WriteLine("Bank has been created!!!");

            
        }
        public List<Transactions> GetTransactions()
        {
            return this.Transactions;
        }
    }
}
