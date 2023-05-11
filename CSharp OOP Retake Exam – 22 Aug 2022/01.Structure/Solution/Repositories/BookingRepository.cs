using BookingApp.Models.Bookings.Contracts;
using BookingApp.Repositories.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Repositories
{
    public class BookingRepository : IRepository<IBooking>
    {
        private readonly ICollection<IBooking> books;

        public BookingRepository()
        {
            books = new List<IBooking>();
        }

        public void AddNew(IBooking model)
        {
            this.books.Add(model);
        }

        public IReadOnlyCollection<IBooking> All()
            => this.books.ToList().AsReadOnly();

        public IBooking Select(string criteria)
        {
            return this.books.FirstOrDefault(b => b.GetType().Name == criteria);
        }
    }
}
