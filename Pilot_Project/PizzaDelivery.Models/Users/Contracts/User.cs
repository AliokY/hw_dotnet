using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Models.Users.Contracts
{
    public abstract class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public User(string name, string login, string password)
        {
            Id = Guid.NewGuid();

            Name = name;
            Login = login;
            Password = password;
        }
    }
}
