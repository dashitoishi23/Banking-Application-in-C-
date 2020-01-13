using System;
using System.Collections.Generic;
using System.Text;

namespace Banking_Application
{
    class Transactions
    {
       public string TransactionID;
       public DateTime TransactionDate;
       public double Amount;
       public string From;
       public string To;

        public Transactions()
        {

        }

        public Transactions(string TransactionID, DateTime transactionTime, double Amount, string From, string To)
        {
            this.TransactionID = TransactionID;
            this.TransactionDate = transactionTime;
            this.Amount = Amount;
            this.From = From;
            this.To = To;
        }
    }
}
