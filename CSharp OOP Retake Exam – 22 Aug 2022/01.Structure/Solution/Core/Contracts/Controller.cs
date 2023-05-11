using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Core.Contracts
{
    public class Controller : IController
    {
        private readonly HotelRepository hotels;

        public Controller()
        {
            hotels = new HotelRepository();
        }

        public string AddHotel(string hotelName, int category)
        {
            if (hotels.All().Any(h => h.FullName == hotelName))
            {
                return $"Hotel {hotelName} is already registered in our platform.";
            }

            IHotel hotel = new Hotel(hotelName, category);

            this.hotels.AddNew(hotel);

            return $"{category} stars hotel {hotelName} is registered in our platform and expects room availability to be uploaded.";
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {

            if (this.hotels.All().FirstOrDefault(x => x.Category == category) == default)
            {
                return $"{category} star hotel is not available in our platform.";
            }

            var orderedHotels =
                this.hotels.All().Where(x => x.Category == category).OrderBy(x => x.Turnover).ThenBy(x => x.FullName);


            foreach (var hotel in orderedHotels)
            {
                var selectedRoom = hotel.Rooms.All()
                    .Where(x => x.PricePerNight > 0)
                    .Where(y => y.BedCapacity >= adults + children)
                    .OrderBy(z => z.BedCapacity).FirstOrDefault();

                if (selectedRoom != null)
                {
                    int bookingNumber = this.hotels.All().Sum(x => x.Bookings.All().Count) + 1;
                    IBooking booking = new Booking(selectedRoom, duration, adults, children, bookingNumber); ;
                    hotel.Bookings.AddNew(booking);
                    return $"Booking number {bookingNumber} for {hotel.FullName} hotel is successful!";
                }
            }

            return "We cannot offer appropriate room for your request.";
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = this.hotels.All().FirstOrDefault(h => h.FullName == hotelName);

            if (hotel == null)
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            StringBuilder result = new StringBuilder();

            result.AppendLine($"Hotel name: {hotelName}");
            result.AppendLine($"--{hotel.Category} star hotel");
            result.AppendLine($"--Turnover: {hotel.Turnover:F2} $");
            result.AppendLine("--Bookings:");
            result.AppendLine();

            if (hotel.Bookings.All().Count > 0)
            {
                foreach (IBooking book in hotel.Bookings.All())
                {
                    result.AppendLine($"{book.BookingSummary()}");
                    result.AppendLine();
                }
            }
            else
            {
                result.AppendLine("none");
            }

            return result.ToString().TrimEnd();
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            if (!hotels.All().Any(h => h.FullName == hotelName))
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            if (roomTypeName != nameof(Apartment) &&
                roomTypeName != nameof(DoubleBed) &&
                roomTypeName != nameof(Studio))
            {
                throw new ArgumentException("Incorrect room type!");
            }

            IHotel hotel = this.hotels.All().FirstOrDefault(h => h.FullName == hotelName);

            if (hotel.Rooms.All().GetType().Name == roomTypeName)
            {
                return "Room type is not created yet!";
            }

            IRoom room = hotel.Rooms.All().FirstOrDefault(r => r.GetType().Name == roomTypeName);

            if (room.PricePerNight != 0)
            {
                throw new InvalidOperationException("Price is already set!");
            }
            
            room.SetPrice(price);

            return $"Price of {room.GetType().Name} room type in {hotelName} hotel is set!";
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            if (!hotels.All().Any(h => h.FullName == hotelName))
            {
                return $"Profile {hotelName} doesn’t exist!";
            }

            if (roomTypeName != nameof(Apartment) &&
                roomTypeName != nameof(DoubleBed) &&
                roomTypeName != nameof(Studio))
            {
                throw new ArgumentException("Incorrect room type!");
            }

            IHotel hotel = this.hotels.All().FirstOrDefault(h => h.FullName == hotelName);

            if (hotel.Rooms.All().GetType().Name == roomTypeName ||
                hotel.Rooms.All().GetType().Name == roomTypeName ||
                hotel.Rooms.All().GetType().Name == roomTypeName)
            {
                return "Room type is already created!";
            }

            IRoom room = new Studio();

            if (roomTypeName == nameof(Studio))
            {
                room = new Studio();
            }
            else if (roomTypeName == nameof(DoubleBed))
            {
                room = new DoubleBed();
            }
            else if (roomTypeName == nameof(Apartment))
            {
                room = new Apartment();
            }

            hotel.Rooms.AddNew(room);

            return $"Successfully added {roomTypeName} room type in {hotelName} hotel!";
        }
    }
}
