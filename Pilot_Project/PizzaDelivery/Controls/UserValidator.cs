using PizzaDelivery.Console.Controls.RegexConstants;
using PizzaDelivery.Console.Repositories.UsersPeps;
using PizzaDelivery.Models.Users;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PizzaDelivery.Console.Controls
{
    static class UserValidator
    {
        // checking in or signing in realize
        internal static Customer CustomerValidation(List<Customer> allUsers, CustomerRepositoryStatic customerRS)
        {
            Customer currentCustomer;
            Guid singInResultId;

            bool customerChoise = SayHello();

            if (customerChoise)
            {
                singInResultId = SignInToApp(allUsers);
                currentCustomer = customerRS.GetById(singInResultId);
            }
            else
            {
                currentCustomer = CreateAccount(customerRS, allUsers);
            }
            
            return currentCustomer;
        }
        /// <summary>
        /// greetings, user choose to sign in or check in to app
        /// </summary>
        /// <returns>false, if user needs to check in</returns>
        internal static bool SayHello()
        {
            string userChoiseStr = AnsiConsole.Prompt(
                      new SelectionPrompt<string>()
                      .Title("Для заказа пиццы Вам необходимо [green]войти[/] " +
                      "или [blue]зарегистрироваться[/]:")
                      .PageSize(3)
                      .AddChoices(new[] { "Вход", "Регистрация" }
                      ));

            bool userChoice = userChoiseStr.Equals("Вход");
            return userChoice;
        }
        /// <summary>
        /// user try to sign in
        /// </summary>
        /// <returns>default customer id, if attemt failed </returns>
        internal static Guid SignInToApp(List<Customer> allUsers)
        {
            Guid signInResultId = default;

            while (true)
            {
                System.Console.WriteLine("Введите логин:");
                string userLogin = System.Console.ReadLine();

                System.Console.WriteLine("Введите пароль:");
                string userPassword = System.Console.ReadLine();

                signInResultId = CheckUserData(userLogin, userPassword, allUsers);
                if (signInResultId != default)
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine("Неверный логин или пароль!");
                    if (ChooseFromTwo("Ввести данные повторно", "Создать аккаунт"))
                    {
                        continue;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            return signInResultId;
        }

        /// <summary>
        /// finds a user in the list of registered
        /// </summary>
        /// <returns>felse, if login and password mismatch with data of registered users</returns>
        internal static Guid CheckUserData(string userLogin, string userPassword, List<Customer> allUsers)
        {
            Customer currentCustomer = allUsers.FirstOrDefault(c => c.Login.Equals(userLogin));

            Guid currentId = default;

            if (currentCustomer != null && currentCustomer.Password.Equals(userPassword))
            {
                currentId = currentCustomer.Id;
            }
            return currentId;
        }

        // simple choise from two items (console)
        internal static bool ChooseFromTwo(string item1, string item2)
        {
            string userChoiseStr = AnsiConsole.Prompt(
                        new SelectionPrompt<string>()
                        .PageSize(3)
                        .AddChoices(new[] { item1, item2 }
                        ));

            bool userChoice = userChoiseStr.Equals(item1);
            return userChoice;
        }

        // creates a new account for the user
        internal static Customer CreateAccount(CustomerRepositoryStatic customerRS, List<Customer> allUsers)
        {
            string customerName = CheckInputData(RegexConst.RegName, "Введите Ваше имя:");

            string customerLogin;
            while (true)
            {
                customerLogin = CheckInputData(RegexConst.RegLogin, "Введите логин:");
                if (allUsers.FirstOrDefault(u => u.Login.Equals(customerLogin)) != null)
                {
                    System.Console.WriteLine("Такой пользователь существует! Введите другой логин.");
                    continue;
                }
                else { break; }
            }

            string customerPassword = CheckInputData(RegexConst.RegPassword, "Введите пароль " +
                "(используя строчные и заглавные буквы, цифры. Длина 8 сиволов):");

            string customerEmail;
            while (true)
            {
                customerEmail = CheckInputData(RegexConst.RegEmail, "Введите email:");
                if (allUsers.FirstOrDefault(u => u.Email.Equals(customerEmail)) != null)
                {
                    System.Console.WriteLine("Такой email существует! Введите другой email.");
                    continue;
                }
                else { break; }
            }

            Customer customer = new Customer(customerName, customerLogin, customerPassword, customerEmail);
            customerRS.Add(customer);

            return customer;
        }

        // checks the input data against a pattern 
        internal static string CheckInputData(string regexExpression, string textMessage)
        {
            string inputData;
            Regex regex = new Regex(regexExpression);
            Match match;

            while (true)
            {
                System.Console.WriteLine(textMessage);

                inputData = System.Console.ReadLine();
                match = regex.Match(inputData);
                if (match.Success)
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine("Некорректный формат. Попробуйте ещё раз.");
                    continue;
                }
            }
            return inputData;
        }
    }
}
