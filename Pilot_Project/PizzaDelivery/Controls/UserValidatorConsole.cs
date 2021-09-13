using PizzaDelivery.Console.Controls.RegexConstants;
using PizzaDelivery.Console.Repositories.PizzaReps.PizzaJsonRep;
using PizzaDelivery.Console.Repositories.UsersPeps;
using PizzaDelivery.Models.Users;
using Spectre.Console;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace PizzaDelivery.Console.Controls
{
    static class UserValidatorConsole
    {
        // checking in or signing in realize
        internal static Customer CustomerValidation(List<Customer> allUsers, CustomerJsonRepository customerRep)
        {
            Customer currentCustomer;
            Guid singInResultId;

            bool customerChoise = SayHello();

            if (customerChoise)
            {
                singInResultId = SignInToApp(allUsers);
                if (singInResultId == default)
                {
                    currentCustomer = CreateAccount(customerRep, allUsers);
                }
                else
                {
                    currentCustomer = customerRep.GetById(singInResultId);
                }
            }
            else
            {
                currentCustomer = CreateAccount(customerRep, allUsers);
            }

            return currentCustomer;
        }
        /// <summary>
        /// greetings, user choose to sign in or check in to app
        /// </summary>
        /// <returns>false, if user needs to check in</returns>
        private static bool SayHello()
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
        private static Guid SignInToApp(List<Customer> allUsers)
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
                        System.Console.Clear();
                        continue;
                    }
                    else
                    {
                        System.Console.Clear();
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
        private static Guid CheckUserData(string userLogin, string userPassword, List<Customer> allUsers)
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
        private static bool ChooseFromTwo(string item1, string item2)
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
        private static Customer CreateAccount(CustomerJsonRepository customerRep, List<Customer> allUsers)
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
            customerRep.Add(customer);

            return customer;
        }

        // checks the input data against a pattern 
        private static string CheckInputData(string regexExpression, string textMessage)
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

        // use the existing address or enter a new one
        internal static string ChooseDeliverAdress(Customer customer, CustomerJsonRepository customerRep)
        {
            string deliveryAdress = customer.CustomerAdress;

            if (customer.CustomerAdress != null)
            {
                System.Console.WriteLine($"Сохранённый адрес: {customer.CustomerAdress}?");
                bool customerChoise1 = ChooseFromTwo("Доставить по текущему адресу", "Изменить адрес");
                if (!customerChoise1)
                {
                    deliveryAdress = GetNewDeliverAdress(customer, customerRep);
                }
            }
            else 
            {
                deliveryAdress = GetNewDeliverAdress(customer, customerRep);
            }
            return deliveryAdress;
        }

        // obtaining a delivery address and the ability to save it as the main
        private static string GetNewDeliverAdress(Customer customer, CustomerJsonRepository customerRep)
        {
            string streetName = CheckInputData(RegexConst.RegStreetName, "Укажите адрес доставки. \n" +
            "Введите название улицы/проспекта:");

            int houseNumberLimit = 400;
            System.Console.WriteLine("Укажите номер дома:");
            int houseNumber = CheckInputNumber(houseNumberLimit);

            int apartmentNumberLimit = 500;
            System.Console.WriteLine("Укажите номер квартиры:");
            int apartmentNumber = CheckInputNumber(apartmentNumberLimit);

            System.Console.WriteLine();

            string inputAdress = $"Улица/проспект: {streetName}, дом {houseNumber}, квартира {apartmentNumber}";

            System.Console.WriteLine("Желаете ли Вы сохранить этот адрес как основной?");
            bool customerChoise2 = ChooseFromTwo("Сохранить адрес", "Продолжить без сохранения");
            if (customerChoise2)
            {
                customer.CustomerAdress = inputAdress;
                customerRep.Update(customer);
            }

            System.Console.Clear();

            return inputAdress;
        }

        private static int CheckInputNumber(int numberLimit)
        {
            int number;

            while (true)
            {
                bool result = Int32.TryParse(System.Console.ReadLine(), out number);
                if (result && 1 <= number && number <= numberLimit)
                {
                    break;
                }
                else
                {
                    System.Console.WriteLine("Пожалуйста, введите корректный номер:");
                    continue;
                }
            }
            return number;
        }


    }
}
