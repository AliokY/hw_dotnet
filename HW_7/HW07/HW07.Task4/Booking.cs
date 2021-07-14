using System;

namespace HW07.Task4.Booking.Com
{
    static class Booking
    {
        internal static void BookTheHotel()
        {
            Console.WriteLine("Where do you want to go?");
            string location = Console.ReadLine().ToLower();

            Console.WriteLine("What are you interested in a room or a whole apartment? Please, enter number 1 if you looking for room and 2 - if apartment");
                int userChoice;

            while (true)
            {
                bool res = int.TryParse(Console.ReadLine(), out userChoice);
                if (!res)
                {
                    Console.WriteLine("Incorrect input! Please, enter nuvber 1 or 2");
                    continue;
                }
                else 
                {
                    break;
                }
            }

            HousingKind housingKind = userChoice == 1 ? HousingKind.room : HousingKind.apartment;

            if (housingKind == HousingKind.room)
            {
                Data.ShowHousingList(Data.allRooms, location);
            }
            else
            {
                Data.ShowHousingList(Data.allApartnments, location);
            }

            Console.WriteLine("You could make a choice. Enter the Name of the Hotel wich you want to book:");
            string hotelName = Console.ReadLine();

            if (housingKind == HousingKind.room)
            {
              // итерация по массиву комнат, сравнение имени каждой комнаты с выбором юзера
            }
            else
            {
                // итерация по массиву апартаментов, сравнение имени с выбором юзера
            }

            // запись выбранного id номера/квартиры в сответствующее поле юзера, запись в соответствующее поле гостинесного номера - "забронировано"
        }

        public enum HousingKind
        {
            room = 1,
            apartment
        }
    }
}
