using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Models.Users
{
    public class User
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public string E_mail { get; set; }
        public User()
        {}
        public User(string name, string login, string password, string e_mail)
        {
            Id = Guid.NewGuid();

            Name = name;
            Login = login;
            Password = password;
            E_mail = e_mail;
        }
    }
}
