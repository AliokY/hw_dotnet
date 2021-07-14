using System;

namespace HW07.Task4.Booking.Com
{
    class Room : Housing
    {
        private int _roomFloor;

        public int RoomFloor
        {
            get
            {
                return _roomFloor;
            }
            set
            {
                if (value > 0 && value < 100)
                {
                    RoomFloor = value;
                }
            }
        }
        public Room(string hotelName, string location, int dailyPrice, bool ownKitchen,
            Bathroom bathroom, bool freeWifi, bool balcony, int roomFloor) : base(hotelName, location, dailyPrice, ownKitchen,
            bathroom, freeWifi, balcony)
        {
            RoomFloor = roomFloor;
        }

        public override void ShowAdditionalInfo()
        {
            Console.WriteLine($"The room situates on the {RoomFloor} floor");
        }
    }
}
