using NUnit.Framework;
using System;
using System.Collections.Generic;

namespace SmartphoneShop.Tests
{
    [TestFixture]
    public class SmartphoneShopTests
    {
        private const int capacity = 5;
        private Shop shop;

        [SetUp]
        public void SetUp()
        {
            shop = new Shop(capacity);
        }

        [TearDown]
        public void TearDown() 
        {
            shop = null;
        }

        [Test]
        public void Test_ShopConstructor()
        {
            List<Smartphone> phones = new List<Smartphone>();

            Assert.AreEqual(5, shop.Capacity);
            Assert.AreEqual(shop.Count, phones.Count);
        }

        [Test]
        public void Test_CapacityThrowsExcpetionWhenNegative()
        {
            Assert.Throws<ArgumentException>(
                () => shop = new Shop(-5)
                );
        }

        [Test]
        public void Test_AddCorrect()
        {
            shop.Add(new Smartphone("Noki", 10));

            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void Test_AddThrowsExceptionWhenModelExists()
        {
            shop.Add(new Smartphone("Noki", 10));

            Assert.Throws<InvalidOperationException>(
                () => shop.Add(new Smartphone("Noki", 10))
                );
        }

        [Test]
        public void Test_AddThrowsExceptionWhenCapacityLimitIsReached()
        {
            shop = new Shop(1);
            shop.Add(new Smartphone("Noki", 10));

            Assert.Throws<InvalidOperationException>(
                () => shop.Add(new Smartphone("Sams", 10))
                );
        }

        [Test]
        public void Test_RemoveCorrect()
        {
            shop.Add(new Smartphone("Noki", 10));
            shop.Add(new Smartphone("Sams", 20));
            shop.Remove("Sams");

            Assert.AreEqual(1, shop.Count);
        }

        [Test]
        public void Test_RemoveThrowsExceptionWhenPhoneNotFound()
        {
            Assert.Throws<InvalidOperationException>(
                () => shop.Remove("Sams")
                );
        }

        [Test]
        public void Test_TestPhoneCorrect()
        {
            Smartphone phone = new Smartphone("Noki", 10);
            shop.Add(phone);
            shop.TestPhone("Noki", 2);

            Assert.AreEqual(8, phone.CurrentBateryCharge);
        }

        [Test]
        public void Test_TestPhoneThrowsExceptionIfPhoneNotFound()
        {
            Smartphone phone = new Smartphone("Noki", 10);
            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(
                () => shop.TestPhone("Sams", 5)
                );
        }

        [Test]
        public void Test_TestPhoneThrowsExceptionIfUsageBiggerThanBattery()
        {
            Smartphone phone = new Smartphone("Noki", 10);
            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(
                () => shop.TestPhone("Noki", 20)
                );
        }

        [Test]
        public void Test_ChargePhoneCorrect()
        {
            Smartphone phone = new Smartphone("Noki", 10);
            shop.Add(phone);

            shop.TestPhone("Noki", 5);

            Assert.AreEqual(5, phone.CurrentBateryCharge);

            shop.ChargePhone("Noki");

            Assert.AreEqual(10, phone.CurrentBateryCharge);
        }

        [Test]
        public void Test_ChargePhoneThrowsExceptionWhenPhoneNotFound()
        {
            Smartphone phone = new Smartphone("Noki", 10);
            shop.Add(phone);

            Assert.Throws<InvalidOperationException>(
                () => shop.ChargePhone("Sams")
                );
        }
    }
}