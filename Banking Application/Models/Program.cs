using System;
using System.Collections.Generic;
using System.Linq;

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
                                Console.WriteLine("Enter Bank Name");
                                string BankName = Console.ReadLine();
                                IEnumerable<Bank> QueryToFindBank =
                                    from bank in manager.Banks
                                    where bank.BankName == BankName
                                    select bank;
                                Bank BankToLogin = QueryToFindBank.ElementAt(0);
                                IEnumerable<AccountHolder> QueryToFindUser =
                                    from holder in BankToLogin.AccountHolders
                                    where holder.UserID == UserID && holder.Password == Password
                                    select holder;
                                if (QueryToFindUser.Count()>0)
                                {
                                    AccountHolder UserAction = QueryToFindUser.ElementAt(0);
                                    Console.WriteLine("Logged In Succesfully");
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
                                            UserAction.DepositAmount(FundsToDeposit);
                                            break;
                                        case 2:
                                            Console.WriteLine("How much To withdraw");
                                            int FundsToWithdraw = Console.Read();
                                            double FundsRemaining = UserAction.WithdrawAmount(FundsToWithdraw);
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
                                                    if (BankIDToTransfer == UserAction.BankID)
                                                        charges = 0;
                                                    else
                                                        charges = BankToLogin.RTGSOwnBank * FundsToTranfer;
                                                    FundsToTranfer += (int)charges;
                                                    IEnumerable<Bank> QueryToFindAccount =
                                                        from BankToSelect in manager.Banks
                                                        where BankToSelect.BankID == BankIDToTransfer
                                                        select BankToSelect;
                                                    Bank BankSelected = QueryToFindAccount.ElementAt(0);
                                                    IEnumerable<Account> QueryToFIndHolder =
                                                        from AccountSelected in BankSelected.Accounts
                                                        where AccountSelected.AccountID == AccountIDToTransfer
                                                        select AccountSelected;
                                                    QueryToFIndHolder.ElementAt(0).Funds += FundsToTranfer;
                                                    IEnumerable<Account> QueryToFindDebitor =
                                                        from accounts in BankToLogin.Accounts
                                                        where accounts.AccountID == UserAction.AccountID
                                                        select accounts;
                                                    QueryToFindDebitor.ElementAt(0).Funds -= FundsToTranfer;
                                                    break;
                                                case 2:
                                                    Console.WriteLine("Funds To transfer");
                                                    FundsToTranfer = Console.Read();
                                                    Console.WriteLine("AccountID To trasnfer To");
                                                    AccountIDToTransfer = Console.ReadLine();
                                                    Console.WriteLine("Bank ID To transfer To");
                                                    BankIDToTransfer = Console.ReadLine();
                                                    charges = 0;
                                                    if (BankIDToTransfer == UserAction.BankID)
                                                        charges = BankToLogin.IMPSOwnBank * FundsToTranfer;
                                                    else
                                                        charges = BankToLogin.IMPSOtherBank * FundsToTranfer;
                                                    FundsToTranfer += (int)charges;
                                                    QueryToFindAccount =
                                                        from BankToSelect in manager.Banks
                                                        where BankToSelect.BankID == BankIDToTransfer
                                                        select BankToSelect;
                                                    BankSelected = QueryToFindAccount.ElementAt(0);
                                                    QueryToFIndHolder =
                                                        from AccountSelected in BankSelected.Accounts
                                                        where AccountSelected.AccountID == AccountIDToTransfer
                                                        select AccountSelected;
                                                    QueryToFIndHolder.ElementAt(0).Funds += FundsToTranfer;
                                                    QueryToFindDebitor =
                                                        from accounts in BankToLogin.Accounts
                                                        where accounts.AccountID == UserAction.AccountID
                                                        select accounts;
                                                    QueryToFindDebitor.ElementAt(0).Funds -= FundsToTranfer;
                                                    break;
                                            }
                                            break;
                                            case 4:
                                                Console.WriteLine("Your Transactions are:-");
                                                List<Transactions> TransactionsToDisplay = UserAction.viewTransactions();
                                                foreach (Transactions transactionToDisplay in TransactionsToDisplay)
                                                {
                                                    Console.WriteLine("TransactionID : " + transactionToDisplay.TransactionID);
                                                    Console.WriteLine("Date of transaction: " + transactionToDisplay.TransactionDate);
                                                    Console.WriteLine("Funds Transferred: " + transactionToDisplay.Amount);
                                                    Console.WriteLine("Beneficiary: " + transactionToDisplay.To);
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
                                Console.WriteLine("Enter Bank Name");
                                BankName = Console.ReadLine();
                                Bankstaff staffHandler = new Bankstaff();
                                QueryToFindBank =
                                    from bank in manager.Banks
                                    where bank.BankName == BankName
                                    select bank;
                                BankToLogin = QueryToFindBank.ElementAt(0);
                                IEnumerable<Bankstaff> QueryToFindBankStaff =
                                    from holder in BankToLogin.BankStaffs
                                    where holder.UserID == UserID && holder.Password == Password
                                    select holder;
                                if (QueryToFindBankStaff.Count() > 0)
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
                                            Console.WriteLine("Enter name");
                                            string accountName = Console.ReadLine();
                                            Console.WriteLine("Enter a user iD");
                                            UserID = Console.ReadLine();
                                            foreach(AccountHolder accountHold in BankToLogin.AccountHolders)
                                            {
                                                if(accountHold.UserID == UserID)
                                                {
                                                    Account newAccount = staffHandler.CreateAccount(accountName, UserID);
                                                    BankToLogin.Accounts.Add(newAccount);
                                                    break;
                                                }
                                            }
                                            break;
                                        case 2:
                                            Console.WriteLine("Enter account ID");
                                            string AccountID = Console.ReadLine();
                                            foreach(Account account in BankToLogin.Accounts)
                                            {
                                                if(account.AccountID == AccountID)
                                                {
                                                    Account tempAccount = staffHandler.UpdateAccount(account);
                                                    BankToLogin.Accounts.Remove(account);
                                                    BankToLogin.Accounts.Add(tempAccount);
                                                }
                                            }
                                            break;
                                        case 3:
                                            Console.WriteLine("Enter account ID");
                                            AccountID = Console.ReadLine();
                                            foreach(Account account in BankToLogin.Accounts)
                                            {
                                                if(account.AccountID == AccountID)
                                                {
                                                    BankToLogin.Accounts.Remove(account);
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
