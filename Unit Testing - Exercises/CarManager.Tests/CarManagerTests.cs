namespace CarManager.Tests
{
    using NUnit.Framework;
    using System;

    [TestFixture]
    public class CarManagerTests
    {
        private Car car;

        [SetUp]
        public void SetUp()
        {
            car = new Car("Toyota", "Corolla", 10, 50);
        }

        [Test]
        public void Test_MakeThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => car = new Car(null, "Corolla", 10, 50), 
                "Car make is not null!"
                );
        }

        [Test]
        public void Test_MakeValueIsValid()
        {
            Assert.AreEqual(car.Make, "Toyota", "Makes are not the same!");
        }

        [Test]
        public void Test_ModelThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => car = new Car("Toyota", null, 10, 50),
                "Car model is not null!"
                );
        }

        [Test]
        public void Test_ModelValueIsValid()
        {
            Assert.AreEqual(car.Model, "Corolla", "Models are not the same!");
        }

        [Test]
        public void Test_FuelConsumptionThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => car = new Car("Toyota", "Corolla", 0, 50),
                "Car fuel consumption is not 0 or smaller!"
                );
        }

        [Test]
        public void Test_FuelConsumptionValueIsValid()
        {
            Assert.AreEqual(car.FuelConsumption, 10, "FuelConsumptions are not the same!");
        }

        [Test]
        public void Test_FuelCapacityThrowsException()
        {
            Assert.Throws<ArgumentException>(
                () => car = new Car("Toyota", "Corolla", 10, 0),
                "Car fuel capacity is not 0 or smaller!"
                );
        }

        [Test]
        public void Test_FuelCapacityValueIsValid()
        {
            Assert.AreEqual(car.FuelCapacity, 50, "FuelCapacitys are not the same!");
        }

        [Test]
        public void Test_CarConstructorWithParameters()
        {
            Assert.AreNotEqual(car, null, "Car is null!");
        }

        [Test]
        public void Test_CarInitilaFuelAmount()
        {
            int expectedFuelAmount = 0;

            Assert.AreEqual(car.FuelAmount, expectedFuelAmount, "Fuel amount is not zero!");
        }

        [Test]
        public void Test_RefuelThrowsExceptionWhenFuelIsZero()
        {
            Assert.Throws<ArgumentException>(
                () => car.Refuel(0),
                "Given fuel is not zero!"
                );
        }

        [Test]
        public void Test_CorrectRefuelForFuelAmount()
        {
            int expectedAmount = 10;

            car.Refuel(10);

            Assert.AreEqual(car.FuelAmount, expectedAmount, "Fuel amount is not right!");
        }

        [Test]
        public void Test_CorrectRefuelFuelAmountForCapacity()
        {
            int expectedAmount = 50;

            car.Refuel(70);

            Assert.AreEqual(car.FuelAmount, expectedAmount, "Fuel amount is not right!");
        }

        [Test]
        public void Test_FuelNeededThrowsExceptionWhenBiggetThanFuelAmount()
        {
            Assert.Throws<InvalidOperationException>(
                () => car.Drive(100),
                "Needed fuel is smaller than fuel amount!"
                );
        }

        [Test]
        public void Test_FuelNeededSmalletThanFuelAmount()
        {
            car.Refuel(20);

            int leftFuel = 10;

            car.Drive(100);

            Assert.AreEqual(leftFuel, car.FuelAmount, "We don't have enough fuel!");
        }

        [Test]
        public void Test_MakeGetter()
        {
            Assert.AreEqual(car.Make, "Toyota", "Getter is not working right!");
        }

        [Test]
        public void Test_ModelGetter()
        {
            Assert.AreEqual(car.Model, "Corolla", "Getter is not working right!");
        }

        [Test]
        public void Test_FuelConsumptionGetter()
        {
            Assert.AreEqual(car.FuelConsumption, 10, "Getter is not working right!");
        }

        [Test]
        public void Test_FuelCapacityGetter()
        {
            Assert.AreEqual(car.FuelCapacity, 50, "Getter is not working right!");
        }

        [Test]
        public void Test_FuelAmountGetter()
        {
            car.Refuel(20);

            Assert.AreEqual(car.FuelAmount, 20, "Getter is not working right!");
        }
    }
}