using System;
using System.Collections.Generic;


namespace Banking_Application
{
    class Program
    {
        static void Main(string[] args)
        {
            Manager manager;
            while (true)
            {
                Console.WriteLine("Hi! Welcome To the ultimate banking console app!");
                Console.WriteLine("Select Login Method!");
                manager = new Manager();
                Console.WriteLine("1. Start with new bank");
                Console.WriteLine("2. Continue with existing bank");
                string inp = Console.ReadLine();
                int input = Convert.ToInt32(inp);
                Console.WriteLine(input);
                switch (input)
                {
                    case 1:
                        Console.WriteLine("1. Create bank");
                        Console.WriteLine("2. Create user");
                        inp = Console.ReadLine();
                        int userInput = Convert.ToInt32(inp);
                        switch (userInput)
                        {
                            case 1:
                                Console.WriteLine("Give a Name To the bank");
                                string NameOfBank = Console.ReadLine();
                                Bank bank = manager.CreateBank(NameOfBank);
                                manager.Banks.Add(bank);
                                break;
                            case 2:
                                Console.WriteLine("1. Account Holder");
                                Console.WriteLine("2. Bank Staff");
                                inp = Console.ReadLine();
                                int usersInput = Convert.ToInt32(inp);
                                switch (usersInput)
                                {
                                    case 1:
                                        manager.CreateUser("Account");
                                        break;
                                    case 2:
                                        manager.CreateUser("Bank");
                                        break;
                                }
                                break;
                        }
                        break;
                    case 2:
                        Console.WriteLine("1. Continue as account holder");
                        Console.WriteLine("2. Continue as bank staff");
                        inp = Console.ReadLine();
                        int userBankInput = Convert.ToInt32(inp);
                        switch (userBankInput)
                        {
                            case 1:
                                Console.WriteLine("Enter user ID");
                                string UserID = Console.ReadLine();
                                Console.WriteLine("Enter Password");
                                string Password = Console.ReadLine();
                                AccountHolder holder = new AccountHolder();
                                int flag = 1;
                                foreach (AccountHolder accountHolder in manager.AccountHolders)
                                {
                                    if (accountHolder.UserID == UserID && accountHolder.Password == Password)
                                    {
                                        holder = accountHolder;
                                        flag = 0;
                                        break;
                                    }
                                }
                                if (flag == 0)
                                {
                                    Console.WriteLine("1.Deposit Money");
                                    Console.WriteLine("2. Withdraw Money");
                                    Console.WriteLine("3. Transfer Funds");
                                    Console.WriteLine("4. View Transactions");
                                    inp = Console.ReadLine();
                                    int holdersInput = Convert.ToInt32(inp);
                                    switch (holdersInput)
                                    {
                                        case 1:
                                            Console.WriteLine("How much To deposit?");
                                            int FundsToDeposit = Console.Read();
                                            holder.DepositAmount(FundsToDeposit);
                                            break;
                                        case 2:
                                            Console.WriteLine("How much To withdraw");
                                            int FundsToWithdraw = Console.Read();
                                            double FundsRemaining = holder.WithdrawAmount(FundsToWithdraw);
                                            if (FundsRemaining == 0)
                                            {
                                                Console.WriteLine("Insuficient Funds");
                                            }
                                            else
                                            {
                                                Console.WriteLine("Funds remaining is " + FundsRemaining);
                                            }
                                            break;
                                        case 3:
                                            Console.WriteLine("Determine the type pf transfer");
                                            Console.WriteLine("1. RTGS");
                                            Console.WriteLine("2. IMPS");
                                            inp = Console.ReadLine();
                                            int transferType = Convert.ToInt32(inp);
                                            switch (transferType)
                                            {
                                                case 1:
                                                    Console.WriteLine("Funds To transfer");
                                                    int FundsToTranfer = Console.Read();
                                                    Console.WriteLine("AccountID To trasnfer To");
                                                    string AccountIDToTransfer = Console.ReadLine();
                                                    Console.WriteLine("Bank ID To transfer To");
                                                    string BankIDToTransfer = Console.ReadLine();
                                                    double charges = 0;
                                                    if (BankIDToTransfer == holder.BankID)
                                                        charges = 0;
                                                    else
                                                        charges = 0.2 * FundsToTranfer;
                                                    FundsToTranfer += (int)charges;
                                                    foreach (AccountHolder hold in manager.AccountHolders)
                                                    {
                                                        if (hold.AccountID == AccountIDToTransfer && hold.BankID == BankIDToTransfer)
                                                        {
                                                            hold.Funds += FundsToTranfer;
                                                            holder.Funds -= FundsToTranfer;
                                                            break;
                                                        }
                                                    }
                                                    break;
                                                case 2:
                                                    Console.WriteLine("Funds To transfer");
                                                    int FundsToTranferIMPS = Console.Read();
                                                    Console.WriteLine("AccountID To trasnfer To");
                                                    string AccountIDToTransferIMPS = Console.ReadLine();
                                                    Console.WriteLine("Bank ID To transfer To");
                                                    string BankIDToTransferIMPS = Console.ReadLine();
                                                    double chargesIMPS = 0;
                                                    if (BankIDToTransferIMPS == holder.BankID)
                                                        chargesIMPS = 0.5 * FundsToTranferIMPS;
                                                    else
                                                        chargesIMPS = 0.6 * FundsToTranferIMPS;
                                                    FundsToTranferIMPS += (int)chargesIMPS;
                                                    foreach (AccountHolder hold in manager.AccountHolders)
                                                    {
                                                        if (hold.AccountID == AccountIDToTransferIMPS && hold.BankID == BankIDToTransferIMPS)
                                                        {
                                                            hold.Funds += FundsToTranferIMPS;
                                                            holder.Funds -= FundsToTranferIMPS;
                                                            break;
                                                        }
                                                    }
                                                    break;
                                                case 4:
                                                    Console.WriteLine("Your Transactions are:-");
                                                    Transactions[] TransactionsToDisplay = holder.viewTransactions();
                                                    foreach (Transactions transactionToDisplay in TransactionsToDisplay)
                                                    {
                                                        Console.WriteLine("TransactionID : " + transactionToDisplay.TransactionID);
                                                        Console.WriteLine("Date of transaction: " + transactionToDisplay.TransactionDate);
                                                        Console.WriteLine("Funds Transferred: " + transactionToDisplay.Amount);
                                                        Console.WriteLine("Beneficiary: " + transactionToDisplay.To);
                                                    }
                                                    break;


                                            }
                                            break;


                                    }
                                }


                                else
                                {
                                    Console.WriteLine("Invalid credentials");
                                }

                                break;
                            case 2:

                                Console.WriteLine("Enter UserID");
                                UserID = Console.ReadLine();
                                Console.WriteLine("Enter Password");
                                Password = Console.ReadLine();
                                Bankstaff staffHandler = new Bankstaff();
                                int fl = 1;
                                foreach (Bankstaff staff in manager.BankStaffs)
                                {
                                    if (staff.UserID == UserID && staff.Password == Password)
                                    {
                                        staffHandler = staff;
                                        fl = 0;
                                        break;
                                    }
                                }
                                if (fl == 0)
                                {
                                    Console.WriteLine("1. Create Account");
                                    Console.WriteLine("2. Update Account");
                                    Console.WriteLine("3. Delete Account");
                                    Console.WriteLine("4. Add Currency");
                                    Console.WriteLine("5. Edit charges");
                                    Console.WriteLine("6. View Transactions in Bank");
                                    Console.WriteLine("7. Revert a transaction");
                                    inp = Console.ReadLine();
                                    userInput = Convert.ToInt32(inp);
                                    switch (userInput)
                                    {
                                        case 1:
                                            Console.WriteLine("What is your Name");
                                            string accountName = Console.ReadLine();
                                            Console.WriteLine("Enter user ID");
                                            UserID = Console.ReadLine();
                                            foreach(AccountHolder accountHold in manager.AccountHolders)
                                            {
                                                if(accountHold.UserID == UserID)
                                                {
                                                    Account newAccount = staffHandler.CreateAccount(accountName, UserID);
                                                    manager.Accounts.Add(newAccount);
                                                    break;
                                                }
                                            }
                                            break;
                                        case 2:
                                            Console.WriteLine("Enter account ID");
                                            string AccountID = Console.ReadLine();
                                            foreach(Account account in manager.Accounts)
                                            {
                                                if(account.AccountID == AccountID)
                                                {
                                                    Account tempAccount = staffHandler.UpdateAccount(account);
                                                    manager.Accounts.Remove(account);
                                                    manager.Accounts.Add(tempAccount);
                                                }
                                            }
                                            break;
                                        case 3:
                                            Console.WriteLine("Enter account ID");
                                            AccountID = Console.ReadLine();
                                            foreach(Account account in manager.Accounts)
                                            {
                                                if(account.AccountID == AccountID)
                                                {
                                                    manager.Accounts.Remove(account);
                                                    Console.WriteLine("Account deleted :)");
                                                }
                                            }
                                            break;
                                        case 4:
                                            foreach(Bank bank in manager.Banks)
                                            {
                                                if(bank.BankID == staffHandler.BankID)
                                                {
                                                    Console.WriteLine("Enter Name of currency");
                                                    string currencyName = Console.ReadLine();
                                                    Console.WriteLine("Enter exchange rate");
                                                    string exchange = Console.ReadLine();
                                                    int ExchangeRate = Convert.ToInt32(exchange);
                                                    bank.Currencies.Add(staffHandler.AddCurrency(currencyName, ExchangeRate));
                                                    Console.WriteLine("Added currency");
                                                }
                                            }
                                            break;
                                        case 5:
                                            foreach(Bank bank in manager.Banks)
                                            {
                                                if(bank.BankID == staffHandler.BankID)
                                                {
                                                    Console.WriteLine("Enter new RTGS charges for same bank");
                                                    inp = Console.ReadLine();
                                                    int rtgsSame = Convert.ToInt32(inp);
                                                    Console.WriteLine("Enter new IMPS charges for same bank");
                                                    inp = Console.ReadLine();
                                                    int impsSame = Convert.ToInt32(inp);
                                                    Console.WriteLine("Enter new RTGS charges for other bank");
                                                    inp = Console.ReadLine();
                                                    int rtgsOther = Convert.ToInt32(inp);
                                                    Console.WriteLine("Enter new IMPS charges for other bank");
                                                    inp = Console.ReadLine();
                                                    int impsOther = Convert.ToInt32(inp);
                                                    bank.RTGSOwnBank = rtgsSame;
                                                    bank.RTGSOwnBank = rtgsOther;
                                                    bank.IMPSOwnBank = impsSame;
                                                    bank.IMPSOwnBank = impsOther;
                                                }
                                            }
                                            break;
                                        case 6:
                                            foreach(Bank bank in manager.Banks)
                                            {
                                                if(bank.BankID == staffHandler.BankID)
                                                {
                                                    List<Transactions> Transactions = bank.GetTransactions();
                                                    foreach (Transactions transactionToDisplay in Transactions)
                                                    {
                                                        Console.WriteLine("TransactionID : " + transactionToDisplay.TransactionID);
                                                        Console.WriteLine("Date of transaction: " + transactionToDisplay.TransactionDate);
                                                        Console.WriteLine("Funds Transferred: " + transactionToDisplay.Amount);
                                                        Console.WriteLine("Beneficiary: " + transactionToDisplay.To);
                                                    }
                                                }
                                            }
                                            break;
                                        case 7:
                                            Console.WriteLine("Enter Transaction ID To be reverted");
                                            string idToRevert = Console.ReadLine();
                                            foreach(Bank bank in manager.Banks)
                                            {
                                                if(bank.BankID == staffHandler.BankID)
                                                {
                                                    foreach(Transactions transaction in bank.GetTransactions())
                                                    {
                                                           if(transaction.TransactionID == idToRevert)
                                                        {
                                                            foreach(Account account in bank.Accounts)
                                                            {
                                                                if(transaction.From == account.AccountID)
                                                                {
                                                                    account.Funds += transaction.Amount;
                                                                }
               
                                                            }
                                                            foreach(Account account in bank.Accounts)
                                                            {
                                                                if(transaction.To == account.AccountID)
                                                                {
                                                                    account.Funds -= transaction.Amount;
                                                                    Console.WriteLine("Reversion successful");
                                                                }
                                                            }
                                                        }
                                                    }
                                                }
                                            }
                                            break;  
                                    }
                                }
                                break;



                        }
                        break;
                    default:
                        Console.WriteLine("Invalid input detected! Terminating...");
                        System.Environment.Exit(0);
                        break;
                }
            }


        }
    }
}
