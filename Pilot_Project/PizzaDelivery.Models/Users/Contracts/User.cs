using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Models.Users.Contracts
{
    [DataContract]
    public abstract class User
    {
        [DataMember]
        public Guid Id { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Login { get; set; }
        [DataMember]
        public string Password { get; set; }
        public User()
        {}
        public User(string name, string login, string password)
        {
            Id = Guid.NewGuid();

            Name = name;
            Login = login;
            Password = password;
        }
    }
}
