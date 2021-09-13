using PizzaDelivery.Models.Users.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace PizzaDelivery.Models.Users
{
    public class Customer : User
    {
        public string Email { get; set; }
        public string CustomerAdress { get; set; }

        public Customer(string name, string login, string password, string email)
            : base(name, login, password)
        {
            Email = email;
        }
    }
}
