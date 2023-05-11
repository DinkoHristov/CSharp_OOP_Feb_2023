using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Rooms.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Bookings
{
    public class Booking : IBooking
    {
        private int residenceDuration;
        private int adultsCount;
        private int childrenCont;

        public Booking(IRoom room, int residenceDuration, int adultsCount, int childrenCount, int bookingNumber)
        {
            Room = room;
            ResidenceDuration = residenceDuration;
            AdultsCount = adultsCount;
            ChildrenCount = childrenCount;
            BookingNumber = bookingNumber;
        }

        public IRoom Room { get; private set; }

        public int ResidenceDuration { 
            get
            {
                return this.residenceDuration;
            }
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Duration cannot be negative or zero!");
                }

                this.residenceDuration = value;
            }
        }

        public int AdultsCount {
            get
            {
                return this.adultsCount;
            }
            private set
            {
                if (value < 1)
                {
                    throw new ArgumentException("Adults count cannot be negative or zero!");
                }

                this.adultsCount = value;
            }
        }

        public int ChildrenCount {
            get
            {
                return this.childrenCont;
            }
            private set
            {
                if (value < 0)
                {
                    throw new ArgumentException("Children count cannot be negative!");
                }

                this.childrenCont = value;
            }
        }

        public int BookingNumber { get; private set; }

        public string BookingSummary()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"Booking number: {BookingNumber}");
            result.AppendLine($"Room type: {Room.GetType().Name}");
            result.AppendLine($"Adults: {AdultsCount} Children: {ChildrenCount}");
            result.AppendLine($"Total amount paid: {TotalPaid():F2} $");

            return result.ToString().TrimEnd();
        }

        private double TotalPaid()
        {
            return Math.Round((ResidenceDuration * Room.PricePerNight), 2);
        }
    }
}
