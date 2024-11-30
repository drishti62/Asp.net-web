using System;
using System.Collections.Generic;

namespace BankingManagementSystem
{
    class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            bank.Run();
        }
    }

    public class Bank
    {
        private Dictionary<string, Account> accounts = new Dictionary<string, Account>();

        public void Run()
        {
            Console.WriteLine("Banking Management System");
            Console.WriteLine("---------------------------");

            while (true)
            {
                Console.WriteLine("1. Create Account");
                Console.WriteLine("2. Deposit");
                Console.WriteLine("3. Withdraw");
                Console.WriteLine("4. Check Balance");
                Console.WriteLine("5. Exit");

                Console.Write("Choose an option: ");
                int option = Convert.ToInt32(Console.ReadLine());

                switch (option)
                {
                    case 1:
                        CreateAccount();
                        break;
                    case 2:
                        Deposit();
                        break;
                    case 3:
                        Withdraw();
                        break;
                    case 4:
                        CheckBalance();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Invalid option. Please choose again.");
                        break;
                }
            }
        }

        private void CreateAccount()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            Console.Write("Enter account holder's name: ");
            string accountHolderName = Console.ReadLine();

            Console.Write("Enter initial balance: ");
            decimal initialBalance = Convert.ToDecimal(Console.ReadLine());

            Account account = new Account(accountNumber, accountHolderName, initialBalance);
            accounts.Add(accountNumber, account);

            Console.WriteLine("Account created successfully.");
        }

        private void Deposit()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            if (accounts.ContainsKey(accountNumber))
            {
                Console.Write("Enter amount to deposit: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());

                accounts[accountNumber].Deposit(amount);
                Console.WriteLine("Deposit successful.");
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        private void Withdraw()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            if (accounts.ContainsKey(accountNumber))
            {
                Console.Write("Enter amount to withdraw: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());

                if (accounts[accountNumber].Withdraw(amount))
                {
                    Console.WriteLine("Withdrawal successful.");
                }
                else
                {
                    Console.WriteLine("Insufficient balance.");
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        private void CheckBalance()
        {
            Console.Write("Enter account number: ");
            string accountNumber = Console.ReadLine();

            if (accounts.ContainsKey(accountNumber))
            {
                // Using string concatenation instead of string interpolation
                Console.WriteLine("Account balance: " + accounts[accountNumber].Balance);
                // Or you can also use string.Format:
                // Console.WriteLine(string.Format("Account balance: {0}", accounts[accountNumber].Balance));
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }
    }

    public class Account
    {
        public string AccountNumber { get; set; }
        public string AccountHolderName { get; set; }
        public decimal Balance { get; set; }

        public Account(string accountNumber, string accountHolderName, decimal balance)
        {
            AccountNumber = accountNumber;
            AccountHolderName = accountHolderName;
            Balance = balance;
        }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if (Balance >= amount)
            {
                Balance -= amount;
                return true;
            }
            return false;
        }
    }
}