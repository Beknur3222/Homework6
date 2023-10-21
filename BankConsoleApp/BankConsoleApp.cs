using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankConsoleApp
{
    class BankConsoleApp
    {
        static void Main(string[] args)
        {
            Bankomat.Bank bank = new Bankomat.Bank();

            Console.WriteLine("Добро пожаловать в консольное приложение банка!");

            Console.Write("Введите ваше имя: ");
            string clientName = Console.ReadLine();

            var client = bank.RegisterClient(clientName);
            Console.WriteLine($"Здравствуйте, , {client.Name}! Вы зарегистрированы как клиент банка.");

            Console.WriteLine("Открываю для вас новый счет...");
            Console.Write("Установите пароль для вашего счета: ");
            string password = Console.ReadLine();
            var account = client.OpenAccount(password);
            Console.WriteLine($"Открыт счет {account.AccountNumber}");

            bool loggedIn = false;
            int attempts = 3;

            while (!loggedIn && attempts > 0)
            {
                Console.Write("Введите пароль от вашего счета:  ");
                string enteredPassword = Console.ReadLine();

                if (enteredPassword == account.Password)
                {
                    Console.WriteLine("Вход выполнен успешно.");
                    loggedIn = true;
                }
                else
                {
                    Console.WriteLine("Неверный пароль. Попыток осталось: " + (--attempts));
                }
            }

            if (loggedIn)
            {
                while (true)
                {
                    Console.WriteLine("\nВыберите действие:");
                    Console.WriteLine("1. Просмотр баланса");
                    Console.WriteLine("2. Внесение средств");
                    Console.WriteLine("3. Снятие средств");
                    Console.WriteLine("4. Выход");

                    string choice = Console.ReadLine();

                    switch (choice)
                    {
                        case "1":
                            Console.WriteLine($"Текущий баланс: ${account.GetBalance()}");
                            break;
                        case "2":
                            Console.Write("Введите сумму внесения: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal depositAmount))
                            {
                                account.Deposit(depositAmount);
                            }
                            else
                            {
                                Console.WriteLine("Неверный ввод.");
                            }
                            break;
                        case "3":
                            Console.Write("Введите сумму снятия: ");
                            if (decimal.TryParse(Console.ReadLine(), out decimal withdrawAmount))
                            {
                                account.Withdraw(withdrawAmount);
                            }
                            else
                            {
                                Console.WriteLine("Неверный ввод.");
                            }
                            break;
                        case "4":
                            Console.WriteLine("До свидания!");
                            return;
                        default:
                            Console.WriteLine("Неверный выбор. Пожалуйста, выберите действие.");
                            break;
                    }
                }
            }
            else
            {
                Console.WriteLine("Вход не выполнен. Завершение приложения.");
            }
        }
    }
}
