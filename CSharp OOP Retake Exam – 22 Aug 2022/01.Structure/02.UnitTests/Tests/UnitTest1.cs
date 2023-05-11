using FrontDeskApp;
using System.Reflection;
using System.Collections.Generic;
using NUnit.Framework;

namespace Tests
{
    [TestFixture]
    public class Tests
    {
        private Room room;
        private Booking booking;
        private Hotel hotel;

        [SetUp]
        public void Setup()
        {
            room = new Room(4, 100);
            booking = new Booking(1, room, 10);
            hotel = new Hotel("Aqua", 5);
        }

        [Test]
        public void Test_HotelNotNull()
        {
            Assert.NotNull(hotel);
        }

        [Test]
        public void Test_HotelPrivateFieldListNotNull()
        {
            Type type = typeof(Hotel);

            FieldInfo fieldInfo = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "rooms");

            FieldInfo fieldInfo2 = type.GetFields(BindingFlags.Instance | BindingFlags.NonPublic)
                .FirstOrDefault(fi => fi.Name == "bookings");

            List<Room> roomValue = fieldInfo.GetValue(hotel) as List<Room>;
            List<Booking> bookingValue = fieldInfo2.GetValue(hotel) as List<Booking>;

            Assert.NotNull(roomValue);
            Assert.NotNull(bookingValue);
        }

        [Test]
        public void Test_HotelProperties()
        {
            Assert.AreEqual("Aqua", hotel.FullName);
            Assert.AreEqual(5, hotel.Category);
        }

        [TestCase(null)]
        [TestCase(" ")]
        [TestCase("        ")]
        public void Test_HotelNameThrowExceptionWhenNullOrWhiteSpace(string hotelName)
        {
            Assert.Throws<ArgumentNullException>(
                () => hotel = new Hotel(hotelName, 5)
                );
        }

        [TestCase(0)]
        [TestCase(6)]
        [TestCase(-1)]
        public void Test_HotelCategoryThrowException(int category)
        {
            Assert.Throws<ArgumentException>(
                () => hotel = new Hotel("Aqua", category)
                );
        }

        [Test]
        public void Test_HotelTurnover()
        {
            Assert.AreEqual(0, hotel.Turnover);
        }

        [Test]
        public void Test_AddRoomCorrect()
        {
            hotel.AddRoom(room);

            Assert.AreEqual(1, hotel.Rooms.Count);
        }

        [Test]
        public void Test_BookRoomCorrect()
        {
            hotel.AddRoom(room);

            hotel.BookRoom(2, 0, 5, 1000);

            Assert.AreEqual(1, hotel.Bookings.Count);
            Assert.AreEqual(500, hotel.Turnover);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-2)]
        public void Test_BookRoomAdultsThrowExceptionWhenZeroOrNegative(int adults)
        {
            Assert.Throws<ArgumentException>(
                () => hotel.BookRoom(adults, 0, 5, 1000)
                );
        }

        [TestCase(-1)]
        [TestCase(-2)]
        public void Test_BookRoomChildrenThrowExceptionWhenNegative(int children)
        {
            Assert.Throws<ArgumentException>(
                () => hotel.BookRoom(2, children, 5, 1000)
                );
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-2)]
        public void Test_BookRoomResidenceDurationThrowExceptionWhenZeroOrNegative(int duration)
        {
            Assert.Throws<ArgumentException>(
                () => hotel.BookRoom(2, 0, duration, 1000)
                );
        }

        [Test]
        public void Test_ConstructorBookingCorrect()
        {
            Assert.NotNull(booking);
            Assert.AreEqual(1, booking.BookingNumber);
            Assert.AreEqual(room, booking.Room);
            Assert.AreEqual(10, booking.ResidenceDuration);

        }

        [Test]
        public void Test_BookingConstructorCorrect()
        {
            Assert.IsNotNull(booking);
        }

        [Test]
        public void Test_BookingNumberCorrect()
        {
            Assert.AreEqual(1, booking.BookingNumber);
        }

        [Test]
        public void Test_RoomCorrect()
        {
            Assert.AreEqual(room, booking.Room);
        }

        [Test]
        public void Test_ResidenceDurationCorrect()
        {
            Assert.AreEqual(10, booking.ResidenceDuration);
        }

        [Test]
        public void Test_RoomConstructorCorrect()
        {
            Assert.NotNull(room);
        }

        [Test]
        public void Test_BedCapacityCorrect()
        {
            Assert.AreEqual(4, room.BedCapacity);
        }

        [Test]
        public void Test_PricePerNightCorrect()
        {
            Assert.AreEqual(100, room.PricePerNight);
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-2)]
        public void Test_BedCapacityThrowExceptionWhenZeroOrLess(int bedCapacity)
        {
            Assert.Throws<ArgumentException>(
                () => room = new Room(bedCapacity, 100)
                );
        }

        [TestCase(0)]
        [TestCase(-1)]
        [TestCase(-2)]
        public void Test_PricePerNightThrowExceptionWhenZeroOrLess(int pricePerNight)
        {
            Assert.Throws<ArgumentException>(
                () => room = new Room(4, pricePerNight)
                );
        }
    }
}