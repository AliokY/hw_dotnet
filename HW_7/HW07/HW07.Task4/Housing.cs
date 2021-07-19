using System;

namespace HW07.Task4.Booking.Com
{
    abstract class Housing
    {
        private Guid _id;

        public Guid id
        {
            get
            {
                return _id;
            }
        }

        public string HotelName { get; set; }

        public string Location { get; set; }

        public int DailyPrice { get; set; }

        public bool OwnKitchen { get; set; }

        public Bathroom OwnBathroom { get; set; }

        public bool FreeWifi { get; set; }

        public bool Balcony { get; set; }

        public bool HousingIsFree { get; set; }

        public enum Bathroom
        {
            own,
            common,
            absent
        }

        public Housing(string hotelName, string location, int dailyPrice, bool ownKitchen, Bathroom bathroom, bool freeWifi, bool balcony)
        {
            _id = Guid.NewGuid();
            HotelName = hotelName;
            Location = location;
            DailyPrice = dailyPrice;
            OwnKitchen = ownKitchen;
            OwnBathroom = bathroom;
            FreeWifi = freeWifi;
            Balcony = balcony;
            HousingIsFree = true;
        }

        public void ShowInfo()
        {
            Console.WriteLine($"Hotel name is {HotelName}, loceted in {Location}, average room price is {DailyPrice}, own kitxhen vailability " +
                $"- {OwnKitchen}, own bathroom valiability - {OwnBathroom}, free WiFi - {FreeWifi}, balcony - {Balcony}.");
            Console.WriteLine($"Object status (booked - false, available - true): {HousingIsFree}");

        }

        public abstract void ShowAdditionalInfo();
    }
}

