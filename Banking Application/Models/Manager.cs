using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Banking_Application
{


    class Manager
    {
        public string UserID;
        public string Password;
        public List<Bank> Banks = new List<Bank>();
        public List<Bankstaff> BankStaffs = new List<Bankstaff>();

        public Bank CreateBank(string Name)
        {
            Currencies currency = new Currencies("INR", 1, true);
            Bank bank = new Bank(0, 2.0, 5.0, 6.0, Name, currency);  
            
            this.Banks.Add(bank);
            foreach(Bank bankDisplay in this.Banks)
            {
                Console.WriteLine(bankDisplay.BankName);
                Console.WriteLine(bankDisplay.BankID);
            }
            return bank;
        }            

        public void CreateUser(string type)
        {
            if(type == "Account")
            {
                Console.WriteLine("Name of holder");
                string Name = Console.ReadLine();
                string AccountID = Name.Substring(0, 3) + DateTime.Now.ToString();
                Console.WriteLine("Enter a bank Name");
                string BankName = Console.ReadLine();
                Console.WriteLine("Address");
                string Address = Console.ReadLine();
                Console.WriteLine("Contact number");
                string Contact = Console.ReadLine();
                Console.WriteLine("Enter UserID which you want");
                string UserID = Console.ReadLine();
                Console.WriteLine("Enter Password");
                string Password = Console.ReadLine();
                string BankID = "";
                int flag = 0;
                foreach(Bank bank in Banks)
                {
                      if(bank.BankName == BankName)
                    {
                        BankID = bank.BankName.Substring(0, 3) + DateTime.Now.ToString();
                        flag = 1;
                        AccountHolder newAccountHolder = new AccountHolder(AccountID, BankID, 0, UserID, Password, Name, Address, Contact);
                        AccountHolders.Add(newAccountHolder);
                        bank.AccountHolders.Add(newAccountHolder);
                        Account account = new Account(UserID, AccountID, 0);
                        bank.Accounts.Add(account);
                        break;
                    }

                }
                if(flag == 0)
                {
                    Console.WriteLine("No bank exists!!");
                }
            }
            else
            {
                string EmployeeID = "";
                Console.WriteLine("Enter an user ID");
                string UserID = Console.ReadLine();
                Console.WriteLine("Enter a Password");
                string Password = Console.ReadLine();
                string builder = "";
                Random random = new Random();
                char ch;
                for (int i = 0; i < 10; i++)
                {
                    ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                    builder+=ch;
                }
                EmployeeID = builder;
                Console.WriteLine("Enter a bank Name");
                string BankName = Console.ReadLine();
                string BankID = "";
                foreach(Bank bank in Banks)
                {
                    if(bank.BankName == BankName)
                    {
                        BankID = bank.BankID;
                        Bankstaff newStaff = new Bankstaff(EmployeeID, BankName, BankID, UserID, Password);
                        this.BankStaffs.Add(newStaff);
                        bank.BankStaffs.Add(newStaff);
                        Console.WriteLine("Bank user created with ID " + EmployeeID);
                    }
                }

            }
        }
    }
}
