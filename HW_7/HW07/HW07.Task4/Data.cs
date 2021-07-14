using System;

namespace HW07.Task4.Booking.Com
{
    static class Data
    {
        public static User[] allUsers { get; private set; }

        public static Apartment[] allApartnments { get; private set; }

        public static Room[] allRooms { get; private set; }

        internal static User[] addUsers()
        {
            allUsers = new User[10];
            allUsers[0] = new User("Alex", "alex94@gmail.com", "1Al15645");
            allUsers[1] = new User("Jack", "jackmor@gmail.com", "123456Jm");
            allUsers[2] = new User("Pablo", "pablo29@yandex.ru", "159Pb789");

            return allUsers;
        }

        internal static void ShowHousingList(Room[] allRooms, string location)
        {
            throw new NotImplementedException();
        }

        internal static User[] addNewUser()
        {
            Console.WriteLine("Enter your name:");
            string name = Console.ReadLine();

            Console.WriteLine("Enter your login");
            string login = Console.ReadLine();

            Console.WriteLine("Enter your password");
            string password = Console.ReadLine();

            for (int i = 0; i < allUsers.Length; i++)
            {
                if (allUsers[i].Login == login)
                {
                    while (allUsers[i].Login == login)
                    {
                        Console.WriteLine("Such a user exists, please enter a new login");
                        login = Console.ReadLine();

                        i = 0;
                    }
                }
            }
            for (int i = 3; i < allUsers.Length; i++)
            {
                if (allUsers[i] == null)
                {
                    allUsers[i] = new User(name, login, password);
                    break;
                }
            }
            return allUsers;
        }

        internal static Apartment[] addApartments()
        {
            allApartnments = new Apartment[3];
            allApartnments[0] = new Apartment("Paradise", "Miami", 150, true, Housing.Bathroom.own, true, true, 4);
            allApartnments[1] = new Apartment("Baltic beach", "Jurmala", 62, true, Housing.Bathroom.common, false, true, 2);
            allApartnments[2] = new Apartment("Oceanica resort", "Remer", 50, false, Housing.Bathroom.absent, true, false, 3);

            return allApartnments;
        }

        internal static Room[] addRooms()
        {
            allRooms = new Room[3];
            allRooms[0] = new Room("Old Bridge", "Grodno", 15, false, Housing.Bathroom.common, false, false, 3);
            allRooms[1] = new Room("Drive Hotel", "Grodno", 17, false, Housing.Bathroom.own, true, false, 1);
            allRooms[1] = new Room("Tourist", "Gomel", 22, true, Housing.Bathroom.absent, true, true, 12);

            return allRooms;
        }

        internal static void ShowHousingList(Apartment[] allApartnments, string location)
        {
            foreach (var apartment in allApartnments)
            {
                if (apartment.Location == location)
                {
                    apartment.ShowInfo();
                    apartment.ShowAdditionalInfo();
                }
            }
        }
    }
}
