using System;
using System.Collections.Generic;
using PizzaDelivery.Models.Users;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PizzaDelivery.Console.Repositories.UsersPeps
{
    class UserRepositoryStatic : IRepository<User>
    {
        public static List<User> _userList = new()
        {
            new User("Сергей", "Serg1989", "vAFEjnDW", "Serg123@gmail.com"),
            new User("Вадим", "Vadim28", "ykE4busM", "Vadim1992@yandex.ru")
        };

        public void Add(User user)
        {
            _userList.Add(user);
        }

        public void Delete(Guid Id)
        {
            _userList.RemoveAll(_ => _.Id == Id);
        }

        public List<User> GetAll()
        {
            return _userList;
        }

        public User GetById(Guid Id)
        {
            return _userList.Find(_ => _.Id.Equals(Id));
        }

        public void Update(User user)
        {
            User updateUser = GetById(user.Id);

            if (updateUser != null)
            {
                updateUser.Login = user.Login;
                updateUser.Password = user.Password;
                updateUser.E_mail = user.E_mail;
            }
            else
            {
                throw new Exception("Такого пользователя не существует!");

            }
        }
    }
}
