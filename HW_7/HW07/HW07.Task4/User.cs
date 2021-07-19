using System;

namespace HW07.Task4.Booking.Com
{
    class User
    {
        public string Name { get; set; }

        public string Login { get; set; }

        private Guid _id;

        public Guid Id
        {
            get { return _id; }
        }

        public Guid bookedHotelId { get; set; }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            set
            {
                while (true)
                {
                    if (value.Length == 8)
                    {
                        _password = value;
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Password must consist of 8 sign, please, try again");
                        value = Console.ReadLine();
                    }
                }
            }
        }
        public User(string name, string login, string password)
        {
            _id = Guid.NewGuid();
            Name = name;
            Login = login;
            Password = password;
        }

        internal User Authorize()
        {
            User currentUser = null;

            Console.WriteLine("Hello! Enter your login, please");
            string login = Console.ReadLine();
            Console.WriteLine("Enter your password, please");
            string password = Console.ReadLine();

            Data.addUsers();

            foreach (var user in Data.allUsers)
            {
                if (user.Login == login && user.Password == password)
                {
                    currentUser = user;
                }
                else
                {
                    Console.WriteLine("Such user does not exist.");
                }
            }
            return currentUser;
        }

    }
}
