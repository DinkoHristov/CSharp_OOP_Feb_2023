using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;

        private RoomRepository rooms;
        private BookingRepository books;

        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;

            rooms = new RoomRepository();
            books = new BookingRepository();
        }

        public string FullName { 
            get
            {
                return this.fullName;
            }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException("Hotel name cannot be null or empty!");
                }

                this.fullName = value;
            }
        }

        public int Category {
            get
            {
                return this.category;
            }
            private set
            {
                if (value < 1 || value > 5)
                {
                    throw new ArgumentException("Category should be between 1 and 5 stars!");
                }

                this.category = value;
            }
        }

        public double Turnover
            => TotalPaid();

        public IRepository<IRoom> Rooms
            => this.rooms;

        public IRepository<IBooking> Bookings
            => this.books;

        private double TotalPaid()
        {
            double totalAmount = 0;

            foreach (var book in this.books.All())
            {
                totalAmount += Math.Round((book.ResidenceDuration * book.Room.PricePerNight), 2);
            }

            return totalAmount;
        }
    }
}
