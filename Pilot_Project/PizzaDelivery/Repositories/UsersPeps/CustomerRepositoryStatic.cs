using System;
using System.Collections.Generic;
using PizzaDelivery.Models.Users;

namespace PizzaDelivery.Console.Repositories.UsersPeps
{
    class CustomerRepositoryStatic : IRepository<Customer>
    {
        public static List<Customer> _userList = new()
        {
            new Customer("Сергей", "Serg1989", "vAFEjnDW", "Serg123@gmail.com"),
            new Customer("Вадим", "Vadim28", "ykE4busM", "Vadim1992@yandex.ru"),
            new Customer("Дмитрий", "Dmitry94", "m8ntKnRj", "Vadim1992@yandex.ru") 
        };

        public void Add(Customer user)
        {
            _userList.Add(user);
        }

        public void Delete(Guid Id)
        {
            _userList.RemoveAll(_ => _.Id == Id);
        }

        public List<Customer> GetAll()
        {
            return _userList;
        }

        public Customer GetById(Guid Id)
        {
            return _userList.Find(_ => _.Id.Equals(Id));
        }

        public void Update(Customer customer)
        {
            Customer updateUser = GetById(customer.Id);

            if (updateUser != null)
            {
                updateUser.Login = customer.Login;
                updateUser.Password = customer.Password;
                updateUser.Email = customer.Email;
            }
            else
            {
                throw new Exception("Такого пользователя не существует!");
            }
        }
    }
}
