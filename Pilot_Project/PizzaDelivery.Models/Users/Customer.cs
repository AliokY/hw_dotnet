using PizzaDelivery.Models.Users.Contracts;
using System.Runtime.Serialization;

namespace PizzaDelivery.Models.Users
{
    [DataContract]
    public class Customer : User
    {
        [DataMember]
        public string Email { get; set; }
        [DataMember]
        public string CustomerAdress { get; set; }
        public Customer()
        {}

        public Customer(string name, string login, string password, string email)
            : base(name, login, password)
        {
            Email = email;
        }
    }
}
