using System;

namespace HW07.Task4.Booking.Com
{
    class Apartment : Housing
    {
        public int RoomsNumber { get; set; }

        public Apartment(string hotelName,string location, int dailyPrice, bool ownKitchen,
            Bathroom bathroom, bool freeWifi, bool balcony, int roomsNumber) : base(hotelName, location, dailyPrice, ownKitchen,
            bathroom, freeWifi, balcony)
        {
            RoomsNumber = roomsNumber;
        }

        public override void ShowAdditionalInfo()
        {
            Console.WriteLine($"This apartment has {RoomsNumber} rooms.");
        }
    }
}
