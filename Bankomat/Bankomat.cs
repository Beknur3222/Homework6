using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    public class Account
    {
        public int AccountNumber { get; private set; }
        public string Password { get; private set; }
        public decimal Balance { get; private set; }

        public Account(int accountNumber, string password)
        {
            AccountNumber = accountNumber;
            Password = password;
            Balance = 0;
        }

        public void Deposit(decimal amount)
        {
            if (amount > 0)
            {
                Balance += amount;
                Console.WriteLine($"Внесено  ${amount}. Новый баланс: ${Balance}");
            }
            else
            {
                Console.WriteLine("Неверная сумма вклада.");
            }
        }

        public bool Withdraw(decimal amount)
        {
            if (amount > 0 && amount <= Balance)
            {
                Balance -= amount;
                Console.WriteLine($"Снято  ${amount}.Новый баланс: ${Balance}");
                return true;
            }
            else
            {
                Console.WriteLine("Неверная сумма снятия или недостаточно средств.");
                return false;
            }
        }

        public decimal GetBalance()
        {
            return Balance;
        }
    }

    public class Client
    {
        public string Name { get; private set; }
        public List<Account> Accounts { get; private set; }

        public Client(string name)
        {
            Name = name;
            Accounts = new List<Account>();
        }

        public Account OpenAccount(string password)
        {
            var random = new Random();
            var accountNumber = random.Next(1000, 10000);
            var account = new Account(accountNumber, password);
            Accounts.Add(account);
            return account;
        }
    }

    public class Bank
    {
        public List<Client> Clients { get; private set; }

        public Bank()
        {
            Clients = new List<Client>();
        }

        public Client RegisterClient(string name)
        {
            var client = new Client(name);
            Clients.Add(client);
            return client;
        }
    }
}