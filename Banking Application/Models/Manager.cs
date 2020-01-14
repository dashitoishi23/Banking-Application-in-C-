using System;
using System.Collections.Generic;
using System.Linq;

namespace Banking_Application
{


    class Manager
    {
        public string UserID { get; set; }
        public string Password { get; set; }
        public List<Bank> Banks = new List<Bank>();

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

                IEnumerable<Bank> LINQQuery =
                    from bank in Banks
                    where bank.BankName == BankName
                    select bank;
                Bank BankFound = LINQQuery.ElementAt<Bank>(0);
                BankID = BankFound.BankID;
                AccountHolder NewHolder = new AccountHolder(AccountID, BankID, 0, UserID, Password, Name, Address, Contact);
                BankFound.AccountHolders.Add(NewHolder);
                Console.WriteLine("Account Holder created succesfully");

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
                IEnumerable<Bank> AddBankStaffLINQQuery =
                    from BankConsidered in Banks
                    where BankConsidered.BankName == BankName
                    select BankConsidered;
                Bank bank = AddBankStaffLINQQuery.ElementAt<Bank>(0);
                BankID = bank.BankID;
                Bankstaff NewStaff = new Bankstaff(EmployeeID, BankName, BankID, UserID, Password);
                bank.BankStaffs.Add(NewStaff);
                Console.WriteLine("Bankstaff created succesfully");
               

            }
        }
    }
}
